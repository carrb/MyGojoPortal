--SELECT DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0)  
--: returns number of days between 0 and when run (today)
--: then adds that number of days back to 0 removing the time

--SELECT DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0)  --: first day of week
--SELECT DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)  --: first day of the month
--SELECT DATEADD(yy, DATEDIFF(yy,0,GETDATE()), 0)  --: first day of the year

--SELECT DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 2)  --: start of the day 2 days from when run

--SELECT DATEADD(mm, DATEDIFF(mm,0,GETDATE()) +2, 0)  --: start of the month 2 months from now


-- To get the last day of the prior month
--SELECT DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)   --: 2010-02-01 00:00:00.000 First day of the month.
--SELECT DATEADD(dd,-1, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))   --: 2010-01-31 00:00:00.000 Add -1 days (Subtract a day).


-- To get the end of the previous day
SELECT DATEADD(ms,-3, DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0))   -- within 3ms accuracy using DateTime
--: 2010-02-26 23:59:59.997 End of the Previous Day(Datetime)
SELECT DATEADD(ns,-100,CAST(DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0) as datetime2))   -- within 100 ns accuracy with DateTime2
--: 2010-02-26 23:59:59.9999999 End of the Previous Day (Datetime2)
