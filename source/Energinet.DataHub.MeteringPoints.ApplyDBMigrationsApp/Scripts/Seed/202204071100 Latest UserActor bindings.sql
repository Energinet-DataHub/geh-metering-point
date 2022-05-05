﻿BEGIN TRANSACTION

-- Permissions for new Endk users to see Endk actors
INSERT INTO [dbo].[UserActor] (UserId, ActorId)
VALUES ('40220326-5d28-4702-a395-b8029038a149', '09591F53-B531-4DB5-BB66-A2F52A393D82'),
       ('6543508b-eb89-4f26-8f8e-6c605631668e', '09591F53-B531-4DB5-BB66-A2F52A393D82'),
       ('b6e55220-cba7-47c5-bb11-5966c8e38a6c', '09591F53-B531-4DB5-BB66-A2F52A393D82'),
       ('a3fc0616-ad9b-4e5e-afa6-fffdedc037f7', '09591F53-B531-4DB5-BB66-A2F52A393D82'),
       ('d4d6db92-1291-4cf6-9512-da859c7b503e', '09591F53-B531-4DB5-BB66-A2F52A393D82'),
       ('8a4a2dd9-cdd0-4dff-9fa9-f774582acaca', '09591F53-B531-4DB5-BB66-A2F52A393D82'),

       ('40220326-5d28-4702-a395-b8029038a149', '83510249-9F7C-4827-A67C-499A3A94F533'),
       ('6543508b-eb89-4f26-8f8e-6c605631668e', '83510249-9F7C-4827-A67C-499A3A94F533'),
       ('b6e55220-cba7-47c5-bb11-5966c8e38a6c', '83510249-9F7C-4827-A67C-499A3A94F533'),
       ('a3fc0616-ad9b-4e5e-afa6-fffdedc037f7', '83510249-9F7C-4827-A67C-499A3A94F533'),
       ('d4d6db92-1291-4cf6-9512-da859c7b503e', '83510249-9F7C-4827-A67C-499A3A94F533'),
       ('8a4a2dd9-cdd0-4dff-9fa9-f774582acaca', '83510249-9F7C-4827-A67C-499A3A94F533'),

       ('40220326-5d28-4702-a395-b8029038a149', '0E223E42-BED4-4778-A973-8D0AD9813F71'),
       ('6543508b-eb89-4f26-8f8e-6c605631668e', '0E223E42-BED4-4778-A973-8D0AD9813F71'),
       ('b6e55220-cba7-47c5-bb11-5966c8e38a6c', '0E223E42-BED4-4778-A973-8D0AD9813F71'),
       ('a3fc0616-ad9b-4e5e-afa6-fffdedc037f7', '0E223E42-BED4-4778-A973-8D0AD9813F71'),
       ('d4d6db92-1291-4cf6-9512-da859c7b503e', '0E223E42-BED4-4778-A973-8D0AD9813F71'),
       ('8a4a2dd9-cdd0-4dff-9fa9-f774582acaca', '0E223E42-BED4-4778-A973-8D0AD9813F71')

-- Permission for EG user
INSERT INTO [dbo].[UserActor] (UserId, ActorId)
VALUES ('7c0f5d09-1afa-4f52-9f51-f00452042395', '08707473-CE69-4699-9780-2C118DD527CF'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '0BECF017-4611-429A-89B5-C194DE60EAC7'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '14F60355-AF6C-4267-A89F-2F20C07EA8AD'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '351FA112-A216-421E-A5F6-42CB73F75F5C'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '3A4FF827-748E-4B1C-A7A2-357E1DA5B4AC'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '4B8ABB49-71F9-465C-9EC3-8F7CBE3F4659'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '51FDC822-EBDD-4882-A80B-EB79CF420479'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '60257177-CEDB-4798-9DA1-452301439DF7'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '7122B8F6-3FE9-4896-A922-DDDE63CC32E8'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '7BA7CBD1-EC9D-4352-AE13-4C04251D75BC'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '7FD4AF08-11E5-46F1-B0E5-29C00C2F733F'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', '91FCC2F8-305A-49A7-8E95-730E49BBB85E'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', 'A363A555-E88B-4CDE-A22B-1FD52854EC05'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', 'AE9FD1EB-B83D-42E2-8D1C-3B0C8F2B9EF2'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', 'B425D950-3E15-44A5-84BF-CF029FF110F6'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', 'EF3E33BD-6963-405D-B1B2-F10929861050'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', 'F52CD834-CC72-4BBE-961C-EA1D71BF854F'),
       ('7c0f5d09-1afa-4f52-9f51-f00452042395', 'FC9DDF32-1985-4831-9C03-9F95AED6F02C')


COMMIT TRANSACTION
