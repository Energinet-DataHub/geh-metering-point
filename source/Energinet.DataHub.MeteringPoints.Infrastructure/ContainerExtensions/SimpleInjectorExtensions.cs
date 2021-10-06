﻿// Copyright 2020 Energinet DataHub A/S
//
// Licensed under the Apache License, Version 2.0 (the "License2");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using System.Reflection;
using Energinet.DataHub.MeteringPoints.Application.Authorization;
using Energinet.DataHub.MeteringPoints.Application.Authorization.AuthorizationHandlers;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess.PostOffice;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Acknowledgements;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Errors;
using Energinet.DataHub.MeteringPoints.Infrastructure.SubPostOffice;
using Energinet.DataHub.MeteringPoints.Infrastructure.SubPostOffice.Bundling;
using MediatR;
using SimpleInjector;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.ContainerExtensions
{
    public static class SimpleInjectorExtensions
    {
        public static void AddAuthorization(this Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            container.Register(typeof(IAuthorizationHandler<,>), typeof(InputAuthorizationHandler<,>));
            container.Collection.Register(typeof(IAuthorizationHandler<,>), new[]
            {
                typeof(ExampleAuthorizationHandler),
            });
        }

        public static void AddValidationErrorConversion(this Container container, bool validateRegistrations, params Assembly[] assemblies)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            var validationErrorTypes = container.GetTypesToRegister(typeof(ValidationError), assemblies).ToList();
            var errorConverterTypes = container.GetTypesToRegister(typeof(ErrorConverter<>), assemblies).ToList();
            container.Register(typeof(ErrorConverter<>), errorConverterTypes, Lifestyle.Singleton);
            container.Register<ErrorMessageFactory>(Lifestyle.Singleton);

            var converterRegistrations = errorConverterTypes
                .Select(container.GetErrorConverterRegistration)
                .ToList();
            container.Collection.Register(typeof(ErrorConverterRegistration), converterRegistrations);

            if (!validateRegistrations)
            {
                return;
            }

            var isAllValidationErrorsCoveredByConverters = validationErrorTypes
                .All(error => converterRegistrations
                    .Find(converter => error == converter.Error) != null);

            if (!isAllValidationErrorsCoveredByConverters)
            {
                var missingRegistrations = validationErrorTypes
                    .Except(converterRegistrations.Select(converterRegistration => converterRegistration.Error))
                    .ToList();
                throw new InvalidOperationException(
                    $"Not all validation errors are covered by error converters. Missing:{Environment.NewLine}{string.Join(Environment.NewLine, missingRegistrations)}");
            }

            var hasDuplicateRegistrations = converterRegistrations
                .GroupBy(registration => registration.Error)
                .Any(group => group.Count() > 1);

            if (hasDuplicateRegistrations)
            {
                var duplicateRegistrations = converterRegistrations
                    .GroupBy(registration => registration.Error)
                    .Where(group => group.Count() > 1)
                    .Select(group => group.Key)
                    .ToList();
                throw new InvalidOperationException(
                    $"There should not be any duplicate error converter registrations, but we found these duplicates:{Environment.NewLine}{string.Join(Environment.NewLine, duplicateRegistrations)}");
            }
        }

        public static void AddSubPostOfficeClient(this Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            container.Register<ISubPostOfficeClient, SubPostOfficeClient>(Lifestyle.Scoped);
            container.Register<IPostOfficeMessageMetadataRepository, PostOfficeMessageMetadataRepository>(Lifestyle.Scoped);

            container.Register<IBundleCreator, BundleCreator>(Lifestyle.Scoped);
            container.Register<IDocumentSerializer<ConfirmMessage>, ConfirmMessageSerializer>(Lifestyle.Singleton);
        }

        public static void AddSubPostOfficeDataAvailableClient(this Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            container.Register<IPostOfficeMessageMetadataRepository, PostOfficeMessageMetadataRepository>(Lifestyle.Scoped);
            container.Register<ISubPostOfficeDataAvailableClient, SubPostOfficeDataAvailableClient>(Lifestyle.Scoped);
        }

        private static ErrorConverterRegistration GetErrorConverterRegistration(this SimpleInjector.Container container, Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (type.BaseType?.GenericTypeArguments.SingleOrDefault() == null) throw new InvalidOperationException("ErrorConverterRegistration not found for type: " + type);

            return new ErrorConverterRegistration(
                type.BaseType.GenericTypeArguments.Single(),
                () => (ErrorConverter)container.GetInstance(type.BaseType));
        }
    }
}
