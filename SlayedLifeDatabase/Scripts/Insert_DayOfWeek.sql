DECLARE @DayOfWeekRecordCount INT 
SET @DayOfWeekRecordCount = (SELECT COUNT(ID) FROM [DayOfWeek])

IF @DayOfWeekRecordCount <= 0 
BEGIN
	INSERT INTO [DayOfWeek](id,[day])VALUES(1, 'Sunday')
	INSERT INTO [DayOfWeek](id,[day])VALUES(2, 'Monday')
	INSERT INTO [DayOfWeek](id,[day])VALUES(3, 'Tuesday')
	INSERT INTO [DayOfWeek](id,[day])VALUES(4, 'Wednesday')
	INSERT INTO [DayOfWeek](id,[day])VALUES(5, 'Thursday')
	INSERT INTO [DayOfWeek](id,[day])VALUES(6, 'Friday')
	INSERT INTO [DayOfWeek](id,[day])VALUES(7, 'Saturday')
END