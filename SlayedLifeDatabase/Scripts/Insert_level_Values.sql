DECLARE @None VARCHAR(40) = 'None',
		@NoneId INT = 1,
		@Bronze VARCHAR(40) = 'Bronze',
		@BronzeId INT = 2,
		@Silver VARCHAR(40) = 'Silver',
		@SilverId INT = 3,
		@Gold VARCHAR(40) = 'Gold',
		@GoldId INT = 4,
		@Diamond VARCHAR(40) = 'Diamond',
		@DiamondId INT = 5,
		@Platinum VARCHAR(40) = 'Platinum',
		@PlatinumId INT = 6,
		@Titanium VARCHAR(40) = 'Titanium',
		@TitaniumId INT = 7,
		@Rhodium VARCHAR(40) = 'Rhodium',
		@RhodiumId INT = 8;

Merge [Level] target 
using
	(
		Values(@NoneId, @None, 1), 
				(@BronzeId, @Bronze, 1),
				(@SilverId, @Silver, 1),
				(@GoldId, @Gold, 1),
				(@DiamondId, @Diamond, 1),
				(@PlatinumId, @Platinum, 1),
				(@TitaniumId, @Titanium, 1),
				(@RhodiumId, @Rhodium, 1)
	)  as source (Id, Name, Active)
		on source.Id = target.Id
		When Matched then 
		update set target.Name = source.name,
				   target.Active = source.active
		When Not matched by target then 
		INSERT(Id, Name, Active)
		Values(source.Id, source.Name, source.Active)
		When Not Matched By source then
		DELETE;
GO