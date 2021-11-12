# Copyright 2020 Energinet DataHub A/S
#
# Licensed under the Apache License, Version 2.0 (the "License2");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
module "azfun_localmessagehub" {
  source                                    = "git::https://github.com/Energinet-DataHub/geh-terraform-modules.git//function-app?ref=1.7.0"
  name                                      = "azfun-localmessagehub-${var.project}-${var.organisation}-${var.environment}"
  resource_group_name                       = data.azurerm_resource_group.main.name
  location                                  = data.azurerm_resource_group.main.location
  storage_account_access_key                = module.azfun_localmessagehub_stor.primary_access_key
  storage_account_name                      = module.azfun_localmessagehub_stor.name
  app_service_plan_id                       = module.azfun_localmessagehub_plan.id
  application_insights_instrumentation_key  = module.appi.instrumentation_key
  tags                                      = data.azurerm_resource_group.main.tags
  always_on                                 = true
  app_settings                              = {
    # Region: Default Values
    WEBSITE_ENABLE_SYNC_UPDATE_SITE       = true
    WEBSITE_RUN_FROM_PACKAGE              = 1
    WEBSITES_ENABLE_APP_SERVICE_STORAGE   = true
    FUNCTIONS_WORKER_RUNTIME              = "dotnet-isolated"
    # Endregion: Default Values
    METERINGPOINT_DB_CONNECTION_STRING    = local.METERING_POINT_CONNECTION_STRING
    MESSAGEHUB_STORAGE_CONNECTION_STRING  = data.azurerm_key_vault_secret.shared_resources_marketoperator_response_connection_string.value
    MESSAGEHUB_QUEUE_CONNECTION_STRING    = data.azurerm_key_vault_secret.shared_resources_integrationevents_transceiver_connection_string.value
    MESSAGEHUB_STORAGE_CONTAINER_NAME     = data.azurerm_key_vault_secret.shared_resources_marketoperator_container_reply_name.value
    METERINGPOINT_QUEUE_CONNECTION_STRING = module.sbnar_meteringpoint_sender.primary_connection_string
    METERINGPOINT_QUEUE_TOPIC_NAME        = module.sbq_meteringpoint.name
  }
  dependencies                              = [
    module.appi.dependent_on,
    module.azfun_localmessagehub_plan.dependent_on,
    module.azfun_localmessagehub_stor.dependent_on,
    module.sbq_meteringpoint.dependent_on,
  ]
}

module "azfun_localmessagehub_plan" {
  source              = "git::https://github.com/Energinet-DataHub/geh-terraform-modules.git//app-service-plan?ref=1.7.0"
  name                = "asp-localmessagehub-${var.project}-${var.organisation}-${var.environment}"
  resource_group_name = data.azurerm_resource_group.main.name
  location            = data.azurerm_resource_group.main.location
  kind                = "FunctionApp"
  sku                 = {
    tier  = "Basic"
    size  = "B1"
  }
  tags                = data.azurerm_resource_group.main.tags
}

module "azfun_localmessagehub_stor" {
  source                    = "git::https://github.com/Energinet-DataHub/geh-terraform-modules.git//storage-account?ref=1.7.0"
  name                      = "stor${random_string.localmessagehub.result}"
  resource_group_name       = data.azurerm_resource_group.main.name
  location                  = data.azurerm_resource_group.main.location
  account_replication_type  = "LRS"
  access_tier               = "Cool"
  account_tier              = "Standard"
  tags                      = data.azurerm_resource_group.main.tags
}

# Since all functions need a storage connected we just generate a random name
resource "random_string" "localmessagehub" {
  length  = 10
  special = false
  upper   = false
}