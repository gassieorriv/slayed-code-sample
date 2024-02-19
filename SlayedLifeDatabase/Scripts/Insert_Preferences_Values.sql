DECLARE @UpdateUserAtLogin VARCHAR(100) = 'Update Info during login',
		@UpdateUserAtLoginId INT = 1,
		@PhoneNotifications VARCHAR(100) = 'Phone Notifications',
		@PhoneNotificationsId INT = 2,
		@EmailNotifications VARCHAR(100) = 'Email Notifications',
		@EmailNotificationsId INT = 3,
		@SharePersonalInfo VARCHAR(100) = 'Share Personal Information',
		@SharePersonalInfoId INT = 4

Merge [Preference] target 
using
	(
		-- no level preferences level 1
		Values(@UpdateUserAtLoginId, @UpdateUserAtLogin, 1), 
			  (@PhoneNotificationsId, @PhoneNotifications, 1),
			  (@EmailNotificationsId, @EmailNotifications, 1),
			  (@SharePersonalInfoId, @SharePersonalInfo, 1)
	)  as source (Id, Name, LevelId)
		on source.Id = target.Id
		When Matched then 
		update set target.Name = source.name,
				   target.levelId = source.levelId
		When Not matched by target then 
		INSERT(Id, Name, levelId)
		Values(source.Id, source.Name, source.levelId)
		When Not Matched By source then
		DELETE;
GO