DELETE FROM Shops;
DELETE FROM Visits;

Declare @AmounOfVisits int
Set @AmounOfVisits = 1000 -- Set amount of test data

Declare @Id int
Set @Id = 1

While @Id <= 100
Begin 
   Insert Into Shops values ('Shop #' + CAST(@Id as nvarchar(10)),
              'Address of shop #' + CAST(@Id as nvarchar(10)))
   Set @Id = @Id + 1
End


Declare @RandomShopId int
Declare @RandomSex int
Declare @RandomAge int
Declare @RandomMood int

Declare @LowerLimitForShopId int
Declare @UpperLimitForShopId int

Set @LowerLimitForShopId = 1
Set @UpperLimitForShopId = 99

Declare @LowerLimitForSex int
Declare @UpperLimitForSex int

Set @LowerLimitForSex = 1
Set @UpperLimitForSex = 2

Declare @LowerLimitForAge int
Declare @UpperLimitForAge int

Set @LowerLimitForAge = 1
Set @UpperLimitForAge = 99

Declare @LowerLimitForMood int
Declare @UpperLimitForMood int

Set @LowerLimitForMood = 1
Set @UpperLimitForMood = 10

DECLARE @FromDate DATETIME
DECLARE @ToDate   DATETIME
DECLARE @RandomDateTime DATETIME

SET @FromDate = '20210101' 
SET @ToDate = CAST(GETDATE() + 1 AS DATETIME)

Declare @count int
Set @count = 1

DECLARE @Days INT

SELECT @Days = DATEDIFF(dd,@FromDate, @ToDate);

While @count <= @AmounOfVisits
Begin

   Select @RandomShopId = Round(((@UpperLimitForShopId - @LowerLimitForShopId) * Rand()) + @LowerLimitForShopId, 0)
   Select @RandomSex = Round(((@UpperLimitForSex - @LowerLimitForSex) * Rand()) + @LowerLimitForSex, 0)
   Select @RandomAge = Round(((@UpperLimitForAge - @LowerLimitForAge) * Rand()) + @LowerLimitForAge, 0)
   Select @RandomMood = Round(((@UpperLimitForMood - @LowerLimitForMood) * Rand()) + @LowerLimitForMood, 0)
	
   Select @RandomDateTime = RAND(CHECKSUM(NEWID())) * @Days + @FromDate

   Insert Into Visits (Date, ShopId, Age, Sex, Mood) values(@RandomDateTime, @RandomShopId, @RandomAge, @RandomSex, @RandomMood)
   Set @count = @count + 1
End