/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\Insert_Preferences_Values.sql
:r .\Insert_level_Values.sql
:r .\Insert_Social_Account_Values.sql
:r .\Insert_StateTaxes.sql
:r .\Insert_DayOfWeek.sql