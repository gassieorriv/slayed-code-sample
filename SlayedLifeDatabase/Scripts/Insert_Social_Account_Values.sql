DECLARE @Facebook VARCHAR(40) = 'Facebook',
		@FacebookId INT = 1,
		@Google VARCHAR(40) = 'Google',
		@GoogleId INT = 2,
		@Instagram VARCHAR(40) = 'Instagram',
		@InstagramId INT = 3,
		@InstagramBusiness VARCHAR(40) = 'Instagram Business',
		@InstagramBusinessId INT = 4,
		@Twitter VARCHAR(40) = 'Twitter',
		@TwitterId INT = 5,
		@Youtube VARCHAR(40) = 'Youtube',
		@YoutubeId INT = 6,
		@Pintrest VARCHAR(40) = 'Pintrest',
		@PintrestId INT = 7

Merge [SocialAccount] target 
using
	(
		Values(@FacebookId, @Facebook), 
				(@GoogleId, @Google),
				(@InstagramId, @Instagram),
				(@InstagramBusinessId, @InstagramBusiness),
				(@TwitterId, @Twitter),
				(@YoutubeId, @Youtube),
				(@PintrestId, @Pintrest)
	)  as source (Id, Name)
		on source.Id = target.Id
		When Matched then 
		update set target.Name = source.name
		When Not matched by target then 
		INSERT(Id, Name)
		Values(source.Id, source.Name)
		When Not Matched By source then
		DELETE;
GO