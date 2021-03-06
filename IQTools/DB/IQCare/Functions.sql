/****** Object:  UserDefinedFunction [dbo].[GetLastDayOfMonth]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastDayOfMonth]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetLastDayOfMonth]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_VLTiming]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_VLTiming]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_VLTiming]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ReOrderRegimens_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_ReOrderRegimens_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_ReOrderRegimens_IQTools]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_OIDrugsGetUnitPrice]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_OIDrugsGetUnitPrice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_OIDrugsGetUnitPrice]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetVisitDate]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetVisitDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetVisitDate]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetViralLoadDate]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetViralLoadDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetViralLoadDate]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetTestCategory]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetTestCategory]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetTestCategory]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetStore]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStore]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetStore]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetStatusMOH_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStatusMOH_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetStatusMOH_IQTools]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetStatusAtGivenDate]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStatusAtGivenDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetStatusAtGivenDate]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRegimenLine]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetRegimenLine]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetRegimenLine]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRegimenCode]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetRegimenCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetRegimenCode]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRegimenAtMonthX]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetRegimenAtMonthX]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetRegimenAtMonthX]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPregnancyStatus]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetPregnancyStatus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetPregnancyStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPreARTStatusMOH_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetPreARTStatusMOH_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetPreARTStatusMOH_IQTools]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetParentFacility]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetParentFacility]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetParentFacility]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetLastDayOfMonthX]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetLastDayOfMonthX]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetLastDayOfMonthX]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetItemOpeningStock]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetItemOpeningStock]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetItemOpeningStock]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetFMAPsPC]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetFMAPsPC]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetFMAPsPC]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetDrugCounts]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetDrugCounts]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetDrugCounts]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCurrentDate]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetCurrentDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetCurrentDate]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCD4Date]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetCD4Date]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetCD4Date]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetARTStatusMOH_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetARTStatusMOH_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetARTStatusMOH_IQTools]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAgeGroup]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetAgeGroup]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetAgeGroup]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAge]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetAge]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetAge]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetActivityAtMonthX]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetActivityAtMonthX]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetActivityAtMonthX]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GestAge]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GestAge]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GestAge]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_FormatRegimen]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_FormatRegimen]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_FormatRegimen]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_diagramobjects]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_diagramobjects]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DatePart]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DatePart]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_DatePart]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateName]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DateName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_DateName]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateDiff]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DateDiff]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_DateDiff]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateAdd]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DateAdd]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_DateAdd]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CDCRegimens]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_CDCRegimens]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_CDCRegimens]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CD4Group]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_CD4Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_CD4Group]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CalcMedian]    Script Date: 3/1/2016 2:47:58 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_CalcMedian]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_CalcMedian]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CalcMedian]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_CalcMedian]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE function [dbo].[fn_CalcMedian] (@flag int, @fromDate datetime, @todate datetime)
returns varchar(200)

as
begin	
	declare @Median varchar(20)
    declare @MedGestAgeAZTStart table(ptn_pk int, GestAge decimal) 
    declare @PresToAZTStartTime table(ptn_pk int, GestAge decimal) 
	declare @MedGestAgeARTStart table(ptn_pk int, GestAge decimal) 
	declare @PresToARTStartTime table(ptn_pk int, GestAge decimal) 

	if @flag = 1
	BEGIN
	


	-- Median gestational age at AZT start
    INSERT @MedGestAgeAZTStart
		select anc.PatientPK, isnull(k.GestationAge,0)
		from tmp_ANCMothers anc
		inner join dbo.tmp_PatientMaster p on p.PatientPK = anc.PatientPK
		inner join  tmp_ARTPatients a on anc.PatientPK = a.PatientPK
		left join tmp_ClinicalEncounters k on k.PatientPK = anc.PatientPK
		where p.RegistrationATPMTCT Between Cast(@fromDate As DATETIME) And Cast(@ToDate As DateTime)
		and a.StartRegimen = ''AZT''  
  
		set @Median = (select median = avg(GestAge)
		from
		(
		 select GestAge = min (cast(GestAge as int)) from
		 (select top 50 percent GestAge = sum (cast(GestAge as int)) from @MedGestAgeAZTStart  
			  group by ptn_pk  order by GestAge desc)a
		   union all
		 select GestAge = max (cast(GestAge as int)) from 
		(select top 50 percent GestAge = sum (cast(GestAge as int)) from @MedGestAgeAZTStart 
			 
		  group by ptn_pk order by GestAge asc) a
		)b)
		
	end
 else if @flag = 2
    begin
        insert @PresToAZTStartTime
		 -- Median time from presentation until AZT start
		select anc.PatientPK, datediff(dd, p.RegistrationATPMTCT, a.StartARTDate)  
		from tmp_ANCMothers anc
		inner join dbo.tmp_PatientMaster p on p.PatientPK = anc.PatientPK
		inner join  tmp_ARTPatients a on anc.PatientPK = a.PatientPK
--		left join tmp_ClinicalEncounters k on k.PatientPK = anc.PatientPK
		where p.RegistrationATPMTCT Between Cast(@fromDate As DATETIME) And Cast(@ToDate As DateTime)
		and a.StartRegimen = ''AZT''  
 

		set @Median = (select median = avg(GestAge)
		from
		(
		 select GestAge = min (GestAge) from
		 (select top 50 percent GestAge = sum (GestAge) from @PresToAZTStartTime  
			  group by ptn_pk  order by GestAge desc)a
		   union all
		 select GestAge = max (GestAge) from 
		(select top 50 percent GestAge = sum (GestAge) from @PresToAZTStartTime 
			 
		  group by ptn_pk order by GestAge asc) a
		)b)
	end
	
 else if @flag = 3
	begin
		-- Median gestational age at ART start
		insert @MedGestAgeARTStart

		select anc.PatientPK, isnull(k.GestationAge,0)
		from tmp_ANCMothers anc
		inner join dbo.tmp_PatientMaster p on p.PatientPK = anc.PatientPK
		inner join  tmp_Pharmacy a on anc.PatientPK = a.PatientPK
		left join tmp_ClinicalEncounters k on k.PatientPK = anc.PatientPK
		where p.RegistrationATPMTCT Between Cast(@fromDate As DATETIME) And Cast(@ToDate As DateTime)
		and a.TreatmentType = ''ART'' 
  

   		set @Median = (select median = avg(GestAge)
		from
		(
		 select GestAge = min (GestAge) from
		 (select top 50 percent GestAge = sum (GestAge) from @MedGestAgeARTStart  
			  group by ptn_pk  order by GestAge desc)a
		   union all
		 select GestAge = max (GestAge) from 
		(select top 50 percent GestAge = sum (GestAge) from @MedGestAgeARTStart 
			 
		  group by ptn_pk order by GestAge asc) a
		 )b)
		
	end

else if @flag = 4
    begin
		insert @PresToARTStartTime
         -- Median time from presentation until ART start
		select anc.PatientPK, datediff(dd, p.RegistrationATPMTCT, a.StartARTDate)  
		from tmp_ANCMothers anc
		inner join dbo.tmp_PatientMaster p on p.PatientPK = anc.PatientPK
		inner join  tmp_ARTPatients a on anc.PatientPK = a.PatientPK
		inner join  tmp_Pharmacy b on anc.PatientPK = b.PatientPK
--		left join tmp_ClinicalEncounters k on k.PatientPK = anc.PatientPK
		where p.RegistrationATPMTCT Between Cast(@fromDate As DATETIME) And Cast(@ToDate As DateTime)
		and b.TreatmentType = ''ART''

		set @Median = (select median = avg(GestAge)
		from
		(
		 select GestAge = min (GestAge) from
		 (select top 50 percent GestAge = sum (GestAge) from @PresToARTStartTime  
			  group by ptn_pk  order by GestAge desc)a
		   union all
		 select GestAge = max (GestAge) from 
		(select top 50 percent GestAge = sum (GestAge) from @PresToARTStartTime 
			 
		  group by ptn_pk order by GestAge asc) a
		 )b)

	end

 return @Median
end

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_CD4Group]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_CD4Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[fn_CD4Group]
(
@cd4  int
)
returns varchar(12) as
begin
declare @cd4group  varchar(12)
set @cd4group =
  case
   when @cd4>0 and @cd4<=200 then ''0-200''
   when @cd4>200 and @cd4<=350 then ''200-350''
   when @cd4>350 and @cd4<=500 then ''350-500''
   when @cd4>500 then ''>500''
  end
return @cd4group
end

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_CDCRegimens]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_CDCRegimens]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[fn_CDCRegimens] (@Regimen nvarchar(30), @RegType nvarchar(30))
returns nvarchar(30)

as
Begin

Declare @CDCRegimen nvarchar(30)

if(@RegType='''' or @RegType Is Null)
	begin
	 If (@Regimen in 
		(	''3TC/D4T15/NVP'',
			''3TC/D4T15/EFV'',
			''3TC/D4T15/LOPr'',
			
			''3TC/D4T20/NVP'',
			''3TC/D4T20/EFV'',
			''3TC/D4T20/LOPr'',
			''3TC/D4T30/NVP'',
			''3TC/D4T30/EFV'',
			''3TC/D4T30/LOPr'',
			''3TC/D4T40/NVP'',
			''3TC/D4T40/EFV'',
			''3TC/D4T40/LOPr'',
			''3TC/AZT/NVP'',
			''3TC/AZT/EFV'',
			''3TC/AZT/LOPr'',
			''3TC/ABC/NVP'',
			''3TC/ABC/EFV'',
			''3TC/ABC/LOPr'',
			''3TC/NVP/TDF'',
			''3TC/EFV/TDF'',
			''3TC/LOPr/TDF'')
	)
	 Begin
	  Set @CDCRegimen = @Regimen
	 end
	else
	begin
	Set @CDCRegimen = ''Others''
	end
end

if(@RegType=''IQTools'')
	begin
	 If (@Regimen in 
		(	''3TC/D4T15/NVP'',
			''3TC/D4T15/EFV'',
			''3TC/D4T15/LOP'',
			''3TC/D4T20/NVP'',
			''3TC/D4T20/EFV'',
			''3TC/D4T20/LOP'',
			''3TC/D4T30/NVP'',
			''3TC/D4T30/EFV'',
			''3TC/D4T30/LOP'',
			''3TC/D4T40/NVP'',
			''3TC/D4T40/EFV'',
			''3TC/D4T40/LOP'',
			''3TC/AZT/NVP'',
			''3TC/AZT/EFV'',
			''3TC/AZT/LOP'',
			''3TC/ABC/NVP'',
			''3TC/ABC/EFV'',
			''3TC/ABC/LOP'',
			''3TC/NVP/TDF'',
			''3TC/EFV/TDF'',
			''3TC/LOP/TDF'')
	)
	 Begin
	  Set @CDCRegimen = @Regimen
	 end
	 else if (@Regimen in (''3TC/D4T/EFV''))
	 begin
	 set @CDCRegimen = ''3TC/D4T30/EFV''
	 end
	 else if (@Regimen in (''3TC/D4T/LOP''))
	 begin
	 set @CDCRegimen = ''3TC/D4T30/LOP''
	 end
	 else if (@Regimen in (''3TC/D4T/NVP''))
	 begin
	 set @CDCRegimen = ''3TC/D4T30/NVP''
	 end
	 else if (@Regimen in (''3TC/ABC/LPV-r''))
	 begin
	 set @CDCRegimen = ''3TC/ABC/LOP''
	 end
	 else if (@Regimen in (''3TC/LPV-r/TDF''))
	 begin
	 set @CDCRegimen = ''3TC/LOP/TDF''
	 end
	 
	else
	begin
	Set @CDCRegimen = ''Others''
	end
end

else if(@RegType=''UMoH2'') 
Begin 
 If (@Regimen in 
		(	''3TC/D4T/NVP'',
			''3TC/D4T/EFV'',
			''3TC/AZT/NVP'',
			''3TC/AZT/EFV'',
			''3TC/NVP/TDF'',
			''3TC/EFV/TDF'',
			''FTC/NVP/TDF'',
			''EFV/FTC/TDF'',
			''AZT/DDI/LOP'',
			''ABC/DDI/LOP'',
			''3TC/AZT/LOP'',
			''ABC/AZT/LOP'',
			''FTC/LOP/TDF'',
			''3TC/LOP/TDF''))
	 Begin
	  Set @CDCRegimen = @Regimen
	 end
	 else if (@Regimen in (''3TC/D4T30/EFV''))
	 begin
	 set @CDCRegimen = ''3TC/D4T/EFV''
	 end
	 else if (@Regimen in (''3TC/D4T30/NVP''))
	 begin
	 set @CDCRegimen = ''3TC/D4T/NVP''
	 end
	else 
	begin
		if(charindex(@Regimen,''LOP'')=0) 
			begin
				Set @CDCRegimen = ''OthersR1''
			end
		else if(charindex(@Regimen,''LOP'')>0) 
			begin
				Set @CDCRegimen = ''OthersR2''
			end
			
	end
END


else if(@RegType=''UMoH'') 
Begin 
 If (@Regimen in 
		(	''3TC/D4T/NVP'',
			''3TC/D4T/EFV'',
			''3TC/AZT/NVP'',
			''3TC/AZT/EFV'',
			''3TC/NVP/TDF'',
			''3TC/EFV/TDF'',
			''FTC/NVP/TDF'',
			''EFV/FTC/TDF'',
			''AZT/DDI/LOPr'',
			''ABC/DDI/LOPr'',
			''3TC/AZT/LOPr'',
			''ABC/AZT/LOPr'',
			''FTC/LOPr/TDF'',
			''3TC/LOPr/TDF''))
	 Begin
	  Set @CDCRegimen = @Regimen
	 end
	else 
	begin
		if(charindex(@Regimen,''LPVr'')=0) 
			begin
				Set @CDCRegimen = ''OthersR1''
			end
		else if(charindex(@Regimen,''LPVr'')>0) 
			begin
				Set @CDCRegimen = ''OthersR2''
			end
	end
END
else if(@RegType=''Nigeria'')
BEGIN
	 If (@Regimen in 
		(	''3TC/D4T/NVP'',
			''3TC/D4T/EFV'',
			''3TC/D4T/LOP'',
			''3TC/AZT/NVP'',
			''3TC/AZT/EFV'',
			''3TC/AZT/LOP'',
			''3TC/ABC/NVP'',
			''3TC/ABC/EFV'',
			''3TC/ABC/LOP'',
			''3TC/NVP/TDF'',
			''3TC/EFV/TDF'',
			''3TC/LOP/TDF'',
			''TDF/FTC/NVP'',
			''TDF/FTC/EFV'',
			''TDF/FTC/LOPr'')
	)
	 Begin
	  Set @CDCRegimen = @Regimen
	 end
	 else if (@Regimen in (''3TC/D4T30/EFV''))
	 begin
	 set @CDCRegimen = ''3TC/D4T/EFV''
	 end
	 else if (@Regimen in (''3TC/D4T30/NVP''))
	 begin
	 set @CDCRegimen = ''3TC/D4T/NVP''
	 end
	else
	begin
	Set @CDCRegimen = ''Others''
	end
end
else if (@RegType=''SCM'')
begin
            if @Regimen   = ''3TC/AZT/3TC/AZT/LOPr/LOPr''
			Set @Regimen = ''3TC/AZT/LOP''
			
			if @Regimen   = ''3TC/AZT/3TC/AZT/LOPr/LOPr''
			Set @Regimen = ''3TC/AZT/LOP''

			if @Regimen  = ''D4T/3TC/D4T/3TC/NVP''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  = ''3TC/NVP/AZT/EFV/3TC/NVP/AZT/EFV''
			set @Regimen = ''3TC/AZT/NVP''

			if @Regimen  = ''3TC/TDF/NVP/NVP/3TC/TDF/NVP/NVP/3TC/TDF/NVP/NVP/NV''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  = ''EFV/3TC/D4T/EFV/3TC/D4T''
			set @Regimen = ''3TC/D4T/EFV''

			if @Regimen  = ''NVP/3TC/NVP/D4T''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  =  ''ABC/ABC/3TC/3TC/NVP''
			set @Regimen = ''3TC/ABC/NVP''

			if @Regimen  =  ''3TC/TDF/NVP/3TC/TDF/NVP/3TC/TDF/NVP/3TC/TDF/NVP''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  =  ''NVP/EFV/3TC/TDF''
			set @Regimen = ''3TC/EFV/NVP''


			if @Regimen  =  ''EFV/3TC/D4T/3TC/D4T/3TC/D4T''
			set @Regimen = ''3TC/D4T/EFV''


			if @Regimen  =  ''3TC/D4T30/NVP''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  =  ''3TC/D4T/LOPr/LOPr''
			set @Regimen = ''3TC/D4T/LOP''

			if @Regimen  =  ''3TC/D4T40/EFV''
			set @Regimen = ''3TC/D4T/EFV''

			if @Regimen  =  ''D4T/3TC/NVP/EFV''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  =  ''3TC/TDF/NVP/NVP''
			set @Regimen = ''3TC/TDF/NVP''

			if @Regimen  =  ''3TC/AZT/3TC/AZT/LOPr/LOPr''
			set @Regimen = ''3TC/AZT/LOP''

			if @Regimen  =  ''3TC/TDF/NVP/3TC/TDF/NVP/NVP''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  =  ''3TC/TDF/NVP/3TC/TDF/NVP''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  =  ''3TC/TDF/LOPr/3TC/TDF/LOPr/LOPr''
			set @Regimen = ''3TC/TDF/LOP''

			if @Regimen  =  ''3TC/AZT/LOPr/3TC/AZT/LOPr/LOPr''
			set @Regimen = ''3TC/AZT/LOP''

			if @Regimen  =  ''3TC/AZT/EFV/EFV''
			set @Regimen = ''3TC/AZT/EFV''

			if @Regimen  =  ''3TC/D4T20/NVP''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  =  ''3TC/D4T30/EFV''
			set @Regimen = ''3TC/D4T/EFV''

			if @Regimen  =  ''3TC/AZT/D4T/3TC/NVP''
			set @Regimen = ''3TC/AZT/D4T''

			if @Regimen  =  ''3TC/NVP/D4T/3TC/NVP/D4T''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  =  ''D4T/3TC/NVP/NVP''
			set @Regimen = ''3TC/D4T/NVP''

			if @Regimen  =  ''EFV/ABC/3TC/EFV/ABC/3TC/EFV/ABC/3TC''
			set @Regimen = ''3TC/ABC/EFV''


			if @Regimen  =  ''NVP/3TC/TDF/NVP/3TC/TDF/NVP''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  =  ''AZT/D4T30/NVP''
			set @Regimen = ''AZT/D4T/NVP''

			if @Regimen  =  ''3TC/NVP/AZT/EFV''
			set @Regimen = ''3TC/AZT/NVP''

			if @Regimen  =  ''3TC/TDF/3TC/TDF/NVP''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  =  ''AZT/EFV/AZT/EFV''
			set @Regimen = ''AZT/EFV''

			if @Regimen  =  ''3TC/ABC/EFV/EFV''
			set @Regimen = ''3TC/ABC/EFV''

			if @Regimen  =  ''EFV/3TC/TDF/EFV/3TC/TDF/EFV/3TC/TDF/EFV/3TC/TDF''
			set @Regimen = ''3TC/EFV/TDF''

			if @Regimen  =  ''EFV/3TC/TDF/EFV/3TC/TDF/EFV/3TC/TDF/EFV/3TC/TDF''
			set @Regimen = ''3TC/EFV/TDF''

			if @Regimen  =  ''LOPr/3TC/NVP/AZT''
			set @Regimen = ''3TC/LOP/NVP''

			if @Regimen  =  ''LOPr/ABC/3TC/LOPr/ABC/3TC/LOPr''
			set @Regimen = ''3TC/ABC/LOP''

			if @Regimen  =  ''3TC/AZT/LOPr/LOPr''
			set @Regimen = ''3TC/AZT/LOP''

			if @Regimen  =  ''3TC/NVP/D4T/3TC/TDF''
			set @Regimen = ''3TC/NVP/D4T''

			if @Regimen  =  ''NVP/3TC/TDF/NVP''
			set @Regimen = ''3TC/NVP/TDF''

			if @Regimen  =  ''EFV/3TC/TDF/EFV/3TC/TDF''
			set @Regimen = ''3TC/EFV/TDF''

			if @Regimen  =  ''3TC/D4T40/NVP''
			set @Regimen = ''3TC/D4T/NVP''


			if @Regimen  =  ''EFV/EFV/ABC/3TC''
			set @Regimen = ''3TC/ABC/EFV''

			if @Regimen  =  ''3TC/NVP/AZT/LOPr''
			set @Regimen = ''3TC/NVP/AZT''

			if @Regimen  =  ''3TC/D4T/EFV/3TC/D4T/EFV''
			set @Regimen = ''3TC/D4T/EFV''

			if @Regimen  =  ''NVP/3TC/TDF/NVP/3TC/TDF''
			set @Regimen = ''3TC/NVP/TDF''

	 If (@Regimen in 
		  (	''AZT'',
			''NVP'',
			''3TC/AZT/NVP'',
			''3TC/AZT/EFV'',
			''3TC/AZT/LOP'',
			''3TC/NVP/TDF'',
			''3TC/LOP/TDF'',
			''3TC/ABC/AZT'',
			''3TC/EFV/TDF'',
			''3TC/AZT/TDF'',
			''3TC/D4T/NVP'',
			''3TC/D4T/EFV'',
			''3TC/ABC/D4T'',
			''3TC/ABC/NVP'',
			''3TC/ABC/EFV'',
			''3TC/AZT/ATV'',
			''3TC/ATV/AZT'',
			''ABC/LOP/TDF'',
			''3TC/ATV/TDF'',
			''ABC/DDI/LOP'',
			''3TC/D4T/LOP'',
			''3TC/ABC/LOP'',
			''3TC/AZT'',
			''3TC/D4T'',
			''3TC/TDF''
		 )
	)
		 Begin
		  Set @CDCRegimen = @Regimen
		 end
 else
		begin
			Set @CDCRegimen = @CDCRegimen
		end
end
Return @CDCRegimen
End

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateAdd]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DateAdd]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_DateAdd]
(
@interval varchar(2)
, @increment int
, @date datetime
) returns datetime as 
begin
declare @datereturn as datetime

if @interval = ''dd'' or @interval = ''d''
begin
set @datereturn = DATEADD(dd,@increment,@date)
end

if @interval = ''mm'' or @interval = ''m''
begin
set @datereturn = DATEADD(mm,@increment,@date)
end

if @interval = ''yy'' or @interval = ''y''
begin
set @datereturn = DATEADD(yy,@increment,@date)
end

return @datereturn
end

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateDiff]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DateDiff]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_DateDiff]
(
@interval varchar(2)
, @date1 datetime
, @date2 datetime
) returns int as

begin

declare @diff as int
if @interval = ''dd'' or @interval = ''d''
begin
set @diff = DATEDIFF(dd, @date1, @date2)
end

if @interval = ''mm'' or @interval = ''m''
begin
set @diff = DATEDIFF(mm, @date1, @date2)
end

if @interval = ''yy'' or @interval = ''y''
begin
set @diff = DATEDIFF(yy, @date1, @date2)
end

return @diff
end' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_DateName]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DateName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_DateName]
(
@interval varchar(2)
, @date datetime
) returns varchar(20) as
begin
declare @dPart as varchar(20)

	if @interval = ''dd'' or @interval = ''d''
	begin
	set @dPart = DATENAME(DD,@date)
	end

	if @interval = ''dw'' 
	begin
	set @dPart = DATENAME(DW,@date)
	end

	if @interval = ''mm'' or @interval = ''m''
	begin
	set @dPart = DATENAME(MM,@date)
	end

	if @interval = ''yy'' or @interval = ''y''
	begin
	set @dPart = DATENAME(YY,@date)
	end

return @dPart
end
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_DatePart]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DatePart]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_DatePart]
(
@interval varchar(2)
, @date datetime
) returns varchar(20) as
begin
declare @dPart as varchar(20)

	if @interval = ''dd'' or @interval = ''d''
	begin
	set @dPart = DATEPART(DD,@date)
	end
	
	if @interval = ''mm'' or @interval = ''m''
	begin
	set @dPart = DATEPART(MM,@date)
	end

	if @interval = ''yy'' or @interval = ''y''
	begin
	set @dPart = DATEPART(YY,@date)
	end

return @dPart
end

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_diagramobjects]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N''dbo''
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N''dbo.sp_upgraddiagrams''),
			@id_sysdiagrams = object_id(N''dbo.sysdiagrams''),
			@id_helpdiagrams = object_id(N''dbo.sp_helpdiagrams''),
			@id_helpdiagramdefinition = object_id(N''dbo.sp_helpdiagramdefinition''),
			@id_creatediagram = object_id(N''dbo.sp_creatediagram''),
			@id_renamediagram = object_id(N''dbo.sp_renamediagram''),
			@id_alterdiagram = object_id(N''dbo.sp_alterdiagram''), 
			@id_dropdiagram = object_id(N''dbo.sp_dropdiagram'')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_FormatRegimen]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_FormatRegimen]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[fn_FormatRegimen](@Regimen VARCHAR(100))

RETURNS VARCHAR(50)

AS

BEGIN
	DECLARE @Formatted VARCHAR(50)
	
	SET @Formatted = @Regimen
	
	SET @Formatted = REPLACE(@Formatted, ''+'', ''/'')
	SET @Formatted = REPLACE(@Formatted, ''(>15YRS ADULT)'', '''')
	SET @Formatted = REPLACE(@Formatted, ''(< 15YRS PAED)'', '''')
	SET @Formatted = REPLACE(@Formatted, ''(<15YRS PAED)'', '''')
	
	SET @Formatted = REPLACE(@Formatted, ''(Adult PEP Option 6)'', '''')
	SET @Formatted = REPLACE(@Formatted, ''(Adult PEP Option 2)'', '''')
	SET @Formatted = REPLACE(@Formatted, ''(Adult PEP Option 1)'', '''')
	SET @Formatted = REPLACE(@Formatted, ''(Paed PEP Option 1)'', '''')
	
	SET @Formatted = REPLACE(@Formatted, ''100-FDC'', '''')
	SET @Formatted = REPLACE(@Formatted, ''PMTCT HAART:'', '''')
	SET @Formatted = REPLACE(@Formatted, ''OI ONLY'', ''OI'')
	SET @Formatted = REPLACE(@Formatted, ''OI Medicines'', ''OI'')
	SET @Formatted = REPLACE(@Formatted, ''SYRUP'', '''')
	
	SET @Formatted = REPLACE(@Formatted, ''ALLUVIA SPECIAL (HYPERLACTEMIA)'', ''LPVr'')
	SET @Formatted = REPLACE(@Formatted, ''NVP OD till end of breastfeeding'', ''NVP'')
	
	SET @Formatted = REPLACE(@Formatted, ''LPV/r'', ''LPVr'')
	SET @Formatted = REPLACE(@Formatted, ''ATV/r'', ''ATVr'')
	SET @Formatted = REPLACE(@Formatted, ''LPR/r'', ''LPRr'')
	SET @Formatted = REPLACE(@Formatted, ''DRV/r'', ''DRVr'')
	
	SET @Formatted = REPLACE(@Formatted, ''LPVr'', ''LOP'')
	SET @Formatted = REPLACE(@Formatted, ''LOPr'', ''LOP'')

	SET @Formatted = REPLACE(@Formatted, '' '', '''')
	
	
	--Order the regimens
	DECLARE @SplitRegimens TABLE( Item VARCHAR(10))
	DECLARE @item VARCHAR(10), @Pos INT, @Ordered VARCHAR(50), @delim VARCHAR(2)
	
	SET @delim = ''/''
	
	SET @Formatted = @Formatted + @Delim
	SET @pos = CHARINDEX(@delim, @Formatted, 1)
	WHILE @pos > 0
	BEGIN
		SET @item = LTRIM(RTRIM(LEFT(@Formatted, @pos - 1)))
		IF @item <> '''' INSERT INTO @SplitRegimens VALUES (CAST(@item AS VARCHAR(10)))
		
		SET @Formatted = SUBSTRING(@Formatted, @pos+1, LEN(@Formatted))
		
		SET @pos = CHARINDEX(@delim, @Formatted, 1)
	END
	SELECT @Ordered = COALESCE(@Ordered + @delim,'''') + item
	FROM (SELECT DISTINCT TOP 10 Item FROM @SplitRegimens ORDER BY Item) t

	RETURN @Ordered
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GestAge]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GestAge]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[fn_GestAge]
(
 @gestage int
)
returns varchar(6) as
begin
 declare @gestagegroup varchar(6)

  set @gestagegroup =
  case
   when  cast(@gestage as int) <20 then ''<20''
   when  cast(@gestage as int) between 20 and 24 then ''20-24''
   when  cast(@gestage as int) between 24 and 28 then ''24-28''
   when  cast(@gestage as int) between 28 and 32 then ''28-32''
   when  cast(@gestage as int) between 32 and 36 then ''32-36''
   when  cast(@gestage as int) >36 then ''>36''
  end
 return @gestagegroup
end
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetActivityAtMonthX]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetActivityAtMonthX]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE Function [dbo].[fn_GetActivityAtMonthX](@PatientPK varchar(100), @Month int)
Returns varchar(100) As
Begin
Declare @Activity As Varchar(100)
Declare @Termination As Varchar(100)

Select @Activity = Max(dbo.fn_GetRegimenCode(a.Drug, ''MoH361B'',b.ageartstart))
From tmp_Pharmacy a Inner Join tmp_ARTPatients b On a.PatientPK = b.PatientPK 
Where TreatmentType = ''ART'' 
And a.PatientPK = @PatientPK
And DateDiff(mm,  b.StartARTDate, a.DispenseDate) = @Month
--And  
--((a.DispenseDate >= b.StartARTDate
--		AND 
--		(DATEPART(mm, a.DispenseDate) - DATEPART(mm, b.StartARTDate) = (@Month - 12) 
--		Or DATEPART(mm, a.DispenseDate) - DATEPART(mm, b.StartARTDate) = @Month)
--		)OR(a.ExpectedReturn >= DateAdd(mm,@Month,b.StartARTDate) And a.DispenseDate < DateAdd(mm,@Month,b.StartARTDate))
--)

Select @Termination = ExitReason
From tmp_ARTPatients a
Where 
DateDiff(mm,  a.StartARTDate, a.ExitDate) = @Month And a.PatientPK = @PatientPK

Return Coalesce(@Termination,@Activity)

End' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAge]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetAge]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE Function [dbo].[fn_GetAge]
(
 @DOB DateTime, 
 @ToDate DateTime
) RETURNS INT AS
BEGIN
 DECLARE @Age int
 SET @Age = FLOOR(DateDiff(day, @DOB, @ToDate)/365.25)
 Return @Age
END

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAgeGroup]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetAgeGroup]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE FUNCTION [dbo].[fn_GetAgeGroup]
(
 @Age int,
 @Type varchar(6)
)
RETURNS varchar(6) AS
BEGIN
 DECLARE @AgeGroup varchar(6)
 IF(@Type=''PEPFAR'')
 BEGIN
  SET @AgeGroup =
  CASE
  WHEN @Age Between 0 And 1 Then ''0-1''
   WHEN @Age Between 2 And 4 Then ''2-4''
   WHEN @Age Between 5 And 14 Then ''5-14''
   WHEN @Age >14 Then ''Adult''
  END
 END
 IF (@Type = ''CROSS'')
 BEGIN
   SET @AgeGroup =
 CASE 
 WHEN @Age  < 1 Then ''<1''
   WHEN @Age Between 1 And 4 Then ''1-4''
   WHEN @Age Between 5 And 14 Then ''5-14''
   WHEN @Age >14 Then ''Adult''
 
 END
 END
 IF (@Type = ''FV'')
 BEGIN
   SET @AgeGroup =
 CASE
   WHEN @Age Between 5 And 14 Then ''5-14'' 
 END
 END
 IF (@Type = ''CARE'')
 BEGIN
   SET @AgeGroup =
 CASE 
 WHEN @Age  < 1 Then ''0 -< 1''
   WHEN @Age Between 1 And 4 Then   ''1 - 4''
   WHEN @Age Between 5 And 9 Then   ''5 - 9''
   WHEN @Age Between 10 And 14 Then ''10-14''
   WHEN @Age Between 15 And 19 Then ''15-19''
   WHEN @Age Between 20 And 24 Then ''20-24''
   WHEN @Age Between 25 And 49 Then ''25-49''
   WHEN @Age >=50 Then ''50 >=''
 END
 END
 IF (@Type = ''FN'')
 BEGIN
   SET @AgeGroup =
 CASE 
 WHEN @Age  < 1 Then ''0-<1''
   WHEN @Age Between 1 And 4 Then ''1-4''
   WHEN @Age Between 5 And 14 Then ''5-14''
   WHEN @Age Between 15 And 17 Then ''15-17''
   WHEN @Age >=18 Then ''18 >=''
 END
 END
  IF (@Type = ''TB'')
 BEGIN
   SET @AgeGroup =
 CASE 
 WHEN @Age  < 1 Then ''0-<1''
   WHEN @Age Between 1 And 4 Then ''1-4''
   WHEN @Age Between 5 And 9 Then ''5-9''
   WHEN @Age Between 10 And 14 Then ''10-14''
   WHEN @Age Between 15 And 19 Then ''15-19''
   WHEN @Age >=20 Then ''20 >=''
 END
 END
 IF (@Type = ''TX_NEW'')
 BEGIN
   SET @AgeGroup =
 CASE 
 WHEN @Age  < 1 Then ''0-<1''
   WHEN @Age Between 1 And 4 Then ''1-4''
   WHEN @Age Between 5 And 9 Then ''5-9''
   WHEN @Age Between 10 And 14 Then ''10-14''
   WHEN @Age Between 15 And 19 Then ''15-19''
   WHEN @Age Between 20 And 24 Then ''20-24''
   WHEN @Age Between 25 And 49 Then ''25-49''
   WHEN @Age >=50 Then ''50 >=''
 END
 END
 IF (@Type = ''TX_CUR'')
 BEGIN
   SET @AgeGroup =
 CASE 
 WHEN @Age  < 1 Then ''0-<1''
   WHEN @Age Between 1 And 4 Then ''1-4''
   WHEN @Age Between 5 And 14 Then ''5-14''
   WHEN @Age Between 15 And 19 Then ''15-19''
   WHEN @Age >=20 Then ''20 >=''
 END
 END
 IF (@Type = ''TX_RET'')
 BEGIN
   SET @AgeGroup =
 CASE 
   WHEN @Age Between 0 And 4 Then ''0-4''
   WHEN @Age Between 5 And 14 Then ''5-14''
   WHEN @Age Between 15 And 19 Then ''15-19''
   WHEN @Age >=20 Then ''20 >=''
 END
 END
ELSE IF(@Type=''MRN'')
 BEGIN
  SET @AgeGroup =
  CASE
   WHEN @Age Between 0 And 1 Then ''0-1''
   WHEN @Age Between 2 And 4 Then ''2-4''
   WHEN @Age Between 5 And 14 Then ''5-14''
	WHEN @Age Between 15 and 17 Then ''15-17''
   WHEN @Age >17 Then ''Adult''
  END
END
 ELSE IF(@Type=''KENYA'')
 BEGIN
  SET @AgeGroup = 
  CASE
   WHEN @Age Between 0 And 18 Then ''0-18''
   WHEN @Age >18 Then ''Adult''
  END
 END
 ELSE IF (@Type=''NORMAL'')
 BEGIN
  SET @AgeGroup = 
  CASE
   WHEN @Age Between 0 And 14.9 Then ''0-14''
   WHEN @Age >= 15 Then ''Adult''
  END
 END
 ELSE IF (@Type=''SCM'')
 BEGIN
  SET @AgeGroup = 
  CASE
   WHEN @Age Between 0 And 15 Then ''Child''
   WHEN @Age >15 Then ''Adult''
  END
 END
 ELSE IF (@Type=''OLDER'')
 BEGIN
  SET @AgeGroup = 
  CASE
   WHEN @Age Between 0  And 1  Then ''0-1''
   when @Age Between 2  And 4  then ''2-4''
   when @Age Between 5  and 14 then ''5-14''
   when @Age Between 15 and 20 then ''15-20''
   when @Age Between 21 and 30 then ''21-30''
   when @Age Between 31 and 40 then ''31-40''
   when @Age Between 41 and 50 then ''41-50''
   when @Age >=51  then ''Over50''
  END
 END
ELSE IF (@Type=''UGANDA'')
 BEGIN
  SET @AgeGroup = 
  CASE
   WHEN @Age = 0  Then ''0''
   when @Age =1   then ''1''
   when @Age Between 2  and 4 then ''2-4''
   when @Age Between 5 and 9 then ''5-9''
   when @Age Between 10 and 14 then ''10-14''
   when @Age Between 15 and 17 then ''15-17''
   when @Age Between 18 and 24 then ''18-24''
   when @Age >=25  then ''Adult''
  END
 END
 ELSE IF (@Type=''UMoH'')
 BEGIN
  SET @AgeGroup = 
  CASE
   WHEN @Age = 0 Then ''0''
   when @Age Between 1  And 4 then ''1-4''
   when @Age Between 5 And 14 then ''5-14''
   when @Age >=15  then ''Adult''
  END
 END
 
 ELSE IF (@Type=''CDC'')
 BEGIN
  SET @AgeGroup = 
  CASE
  WHEN @Age <1 then ''<1''
   WHEN @Age Between 1  And 4 then ''1-4''
   when @Age Between 5  And 9 then ''5-9''
   when @Age Between 10  And 14 then ''10-14''
   when @Age Between 15  And 19 then ''15-19''
   when @Age Between 20  And 24 then ''20-24''
   when @Age Between 25  And 49 then ''25-49''
   when @Age >=50  then ''50+''
  END
 END
 RETURN @AgeGroup
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetARTStatusMOH_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetARTStatusMOH_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE Function [dbo].[fn_GetARTStatusMOH_IQTools](@PatientPK Int, @toDate datetime) RETURNS VARCHAR(100) AS
BEGIN

Declare @Status as varchar(100)

Select @Status = CASE 
WHEN d.ExitDate <= @todate THEN SUBSTRING(d.ExitReason,1,1)
WHEN DATEDIFF(dd, c.LA, @todate) BETWEEN 30 AND 90 THEN ''F''
WHEN DATEDIFF(dd, c.LA, @todate) > 90 OR c.PatientPK IS NULL THEN ''L''
ELSE ''V'' END 

 FROM tmp_PatientMaster a
INNER JOIN tmp_ARTPatients b ON a.PatientPK = b.PatientPK
LEFT JOIN
(Select a.PatientPK, MAX(a.VisitDate) LV
, MAX(a.NextAppointmentDate)  LA 
From (Select PatientPK, VisitDate
, MAX(CASE WHEN NextAppointmentDate IS NULL THEN DATEADD(dd,30,VisitDate) ELSE NextAppointmentDate END) AS NextAppointmentDate
FROM tmp_ClinicalEncounters 
GROUP BY PatientPK, VisitDate) a
Where VisitDate <= @todate
GROUP BY PatientPK
)c ON a.PatientPK = c.PatientPK

LEFT JOIN tmp_LastStatus d ON a.PatientPK = d.PatientPK

Where b.StartARTDate <= @todate
AND a.PatientPK = @patientPK

RETURN @Status 
END' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCD4Date]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetCD4Date]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[fn_GetCD4Date] (@PatientPK INT, @num INT)

RETURNS DATETIME

AS
BEGIN
	DECLARE @CD4Dates TABLE( Id  INT IDENTITY(1,1) PRIMARY KEY, CD4Date DATETIME)
	DECLARE @CD4Date DATETIME
	
	INSERT INTO @CD4Dates(CD4Date )
	SELECT DISTINCT TOP 10 ReportedbyDate FROM dbo.tmp_Labs
	WHERE TestName LIKE ''CD4%'' AND PatientPK = @PatientPK ORDER BY ReportedbyDate DESC
	
	SET @CD4Date = (SELECT TOP 1 CD4Date FROM @CD4Dates WHERE id = @num)
	
	RETURN @CD4Date
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCurrentDate]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetCurrentDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_GetCurrentDate]() returns datetime as
begin
declare @currDate as datetime
set @currDate = GETDATE()
return @currDate
end




' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetDrugCounts]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetDrugCounts]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[fn_GetDrugCounts] (@flag int, @ItemName varchar(200), @FromDate datetime, @ToDate datetime, @Store varchar(200))
-- dbo].[fn_GetDrugCounts]
returns varchar(200)      
as 
        
begin 
declare @ans varchar(200), @storeid int
set @storeid = (select id from mst_store where Name = @Store)


 -- 1. Beginning balance per ART
 if @flag = 1 
    set @ans = 
		isnull((select nullif((dbo.fn_GetItemOpeningStock(a.Drug_pk,@storeid,@FromDate)),0)[OpeningQuanitity]              
				from mst_drug a Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                    
				where a.DrugName =  @ItemName group by a.drug_pk,a.drugname,c.name),0)
				
 if @flag = 12
    set @ans = 
		isnull((select nullif((dbo.fn_GetItemOpeningStock(a.Drug_pk,@storeid,@FromDate)),0)[OpeningQuanitity]              
				from mst_drug a Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                    
				where a.DrugName =  @ItemName group by a.drug_pk,a.drugname,c.name),0)
			
	   

 -- 2. Qty received this period   
 else if @flag = 2
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)

		 
 else if @flag = 21
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)			
				 
 else if @flag = 22
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	
				 
				 
  else if @flag = 23
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	

  else if @flag = 24
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	
				 
				 
  else if @flag = 25
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	
				 
  else if @flag = 26
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	
				 
  else if @flag = 27
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	
				 
  else if @flag = 28
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)	
				 
				 
  else if @flag = 29
  set @ans = isnull((select sum(q.RecQty)[RecQty] from                
				 (select a.Drug_Pk,a.DrugName,c.Name [DispensingUnit], sum(Quantity)[RecQty]                         
				 from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
				 Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
				 where b.Openingstock IS NULL and  b.AdjustId IS NULL and (b.GrnId is not null or b.GrnId > 0)                         
				 and b.Quantity>0 and b.ExpiryDate>=@FromDate and a.DrugName = @ItemName and                   
				 b.transactiondate >=@FromDate and b.transactiondate<@ToDate and b.StoreID = @storeid                        
				 group by a.drug_pk,a.drugname,c.name having sum(Quantity) >= 0)q         
				 group by q.drug_pk, q.drugname, q.dispensingunit),0)					 				 				 				 				 			 				 			 	 

 
 -- 3. Total Quantity Dispensed this period
 else if @flag = 3
	 set @ans = isnull((select abs(sum(Quantity)) [IssQty]                         
					from mst_drug a inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
					Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
					where b.Ptn_Pharmacy_pk > 0 and b.transactiondate >=@FromDate and b.transactiondate<@ToDate and a.DrugName  = @ItemName  
					and b.StoreID = @storeid                 
					group by b.StoreId, a.drug_pk,a.drugname,c.name),0)

 -- 5. Adjustments (Borrowed from or Issued out to Other Facilities)
 else if @flag = 4
	set @ans = 
		isnull((select sum(b.Quantity)[AdjustmentQuantity]                         
		from mst_drug a Inner join dtl_stocktransaction b on a.Drug_Pk = b.ItemId                        
		Left Outer join Mst_DispensingUnit c on a.DispensingUnit = c.Id                        
		where                            
		b.ExpiryDate>=@FromDate and b.AdjustId IS NOT NULL and                   
		b.transactiondate >=@FromDate and b.transactiondate<@ToDate and a.Drugname = @ItemName 
		and b.storeid = @storeid                      
		group by a.drug_pk,a.drugname,c.name),0)

-- 4. Losses (Damages, Expiries, Missing)
 else if @flag = 5
	set @ans = isnull((select sum(abs(AdjustmentQuantity)) from Dtl_AdjustStock g join mst_Decode d on d.ID = g.AdjustReasonId
		join mst_drug dr on dr.Drug_pk = g.ItemId
		join ord_AdjustStock a on a.AdjustId = g.AdjustId and a.StoreId = g.StoreId
		where dr.DrugName = @ItemName and d.Name in (''Damaged'',''Expired'',''Missing'') 
		and a.AdjustmentDate  between @FromDate and @ToDate),0)
	
-- 6. Expiry Dates		
else if @flag = 6
	set @ans = isnull(cast((Select top 1 c.ExpiryDate from mst_drug a inner join Dtl_StockTransaction c on a.Drug_pk=c.itemid            
	where a.DrugName = @ItemName and c.ExpiryDate < dateadd(mm, 6, getdate())  and c.ExpiryDate>=@FromDate order by c.ExpiryDate asc) as varchar),'''')

	return @ans	 
end 

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetFMAPsPC]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetFMAPsPC]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

----=========================
CREATE function [dbo].[fn_GetFMAPsPC] (@flag int)
returns int
as

begin
    declare @result int 
	if @flag = 1      -- PC1
		set @result = (select count(distinct a.PatientPK) Total
		from dbo.tmp_Pharmacy a join dbo.tmp_PatientMaster p on a.PatientPK = p.PatientPK
		where a.DispenseDate between p.DOB and dateadd(ww, 6, p.DOB) and a.Drug = ''NVP'' and p.StatusAtCCC = ''Active'')
	else if @flag = 2 -- PC2
		set @result =  (select count(distinct a.PatientPK) Total
		from tmp_Pharmacy a join dbo.tmp_PatientMaster p on a.PatientPK = p.PatientPK
		join dbo.tmp_ClinicalEncounters c on c.PatientPK = a.PatientPK
		where a.dispenseDate between p.DOB and dateadd(yy, 1, p.DOB) and a.Drug = ''NVP'' 
		and c.FeedingOption like ''%BF%'' and c.FeedingOption not like ''%NBF%'' and p.StatusAtCCC = ''Active'')
		
	else if @flag = 3 -- PC3
		set @result = 0

return @result
end

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetItemOpeningStock]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetItemOpeningStock]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE  Function [dbo].[fn_GetItemOpeningStock]    
(    
  @ItemId int,    
  @StoreId int,    
  @OpeningDate datetime     
)    
returns int    
as    
begin    
  declare @OpQty1 int   
  select @OpQty1 = isnull(sum(Quantity),0) from dtl_StockTransaction where ItemId = @ItemId and StoreId = @StoreId    
  and TransactionDate < @OpeningDate and ExpiryDate >= getdate()     
  
  return @OpQty1  
end  ' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetLastDayOfMonthX]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetLastDayOfMonthX]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_GetLastDayOfMonthX](@TheDate as datetime)
Returns Datetime
AS
Begin
return DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@TheDate)+1,0))
End
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetParentFacility]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetParentFacility]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE Function [dbo].[fn_GetParentFacility](@FacilityName varchar(100))
Returns Varchar(100)
as
Begin
Declare @ParentFacility As varchar(100)

If @FacilityName = ''Baraka Dispensary(Nairobi)''
Set @ParentFacility = ''Baraka''
Else If @FacilityName = ''Chogoria (PCEA) Hospital''
Set @ParentFacility = ''Chogoria''
Else If @FacilityName = ''Consolata Mission Hospital (Mathari)''
Set @ParentFacility = ''Consolata''
Else If @FacilityName = ''St. Luke''''s Mission Hospital''
Set @ParentFacility = ''Kaloleni''
Else If @FacilityName In (''Thigio Dispensary(Kiambu West)'',''Kijabe (AIC) Hospital'')
Set @ParentFacility = ''Kijabe''
Else If @FacilityName = ''Kikuyu (PCEA) Hospital''
Set @ParentFacility = ''Kikuyu''
Else If @FacilityName = ''North Kinangop Catholic Hospital''
Set @ParentFacility = ''Kinangop''
Else If @FacilityName In (''Makadara Sisters of Mercy'',''The Mater Hospital Mukuru'')
Set @ParentFacility = ''Mater''
Else If @FacilityName = ''Maua Methodist Hospital''
Set @ParentFacility = ''Maua''
Else If @FacilityName In (''St James Catholic Church Mtopanga'',''Chaani Holy Cross Catholic Church'',''Mikindani Catholic Dispensary'',''St Martin Catholic Church Mbungoni'')
Set @ParentFacility = ''Mikindani''
Else If @FacilityName = ''Mutomo Hospital''
Set @ParentFacility = ''Mutomo''
Else If @FacilityName In (''Mwea Medical Clinic Kagio'',''Mwea Mission (Our Lady Of Lourdes) Hospital'')
Set @ParentFacility = ''Mwea''
Else If @FacilityName = ''Naivasha''
Set @ParentFacility = ''Naivasha''
Else If @FacilityName In (''Nazareth Hospital Annex(Ruiru)'',''Nazareth Hospital'',''Tinganga Catholic Dispensary'',''St.Charles Lwanga Dispensary(Limuru)'',''St Mary Health Centre (Kiserian)'',''St.Joseph Catholic Dispensary(kahawa)'',''St Joseph the worker Dispensary (Westlands)'',''Sacred Heart Dispensary'')
Set @ParentFacility = ''Nazareth''
Else If @FacilityName = ''Tumutumu (PCEA) Hospital''
Set @ParentFacility = ''Tumutumu''
Else If @FacilityName = ''St. Joseph Shelter Of Hope''
Set @ParentFacility = ''Voi''
Else If @FacilityName = ''AIC Githumu Hospital''
Set @ParentFacility = ''Githumu''

Else If @FacilityName = ''Friends Lugulu Mission Hospital''
Set @ParentFacility = ''Lugulu''
Else If @FacilityName In (''St Monica Rapogi Health Centre'',''Rakwaro'')
Set @ParentFacility = ''Rapogi''
Else If @FacilityName In (''Holy Family Oriang Mission Dispensary'',''St. Mary''''s Ringa Dispensary'')
Set @ParentFacility = ''Oriang''
Else If @FacilityName = ''Maseno Mission Hospital''
Set @ParentFacility = ''Maseno''
Else If @FacilityName In (''St.Elizabeth Lwak Mission Health Centre'',''Nyangoma Mission Health Centre'',''Rangala Health Centre'')
Set @ParentFacility = ''Lwak''
Else If @FacilityName In (''Mukumu Hospital'',''Musoli Health Clinic'',''Kakamega Forest Dispensary'')
Set @ParentFacility = ''Mukumu''
Else If @FacilityName = ''Nyabondo Mission Hospital''
Set @ParentFacility = ''Nyabondo''
Else If @FacilityName = ''Kendu Adventist Hospital''
Set @ParentFacility = ''Kendu''
Else If @FacilityName In (''St Joseph Mission Hospital'',''Angiya Dispensary'',''Arombe Dispensary'')
Set @ParentFacility = ''Migori''
Else If @FacilityName In (''Asumbi Health Centre'',''Oyugis Satelitte'',''St Pauls Mission Hospital'')
Set @ParentFacility  = ''Asumbi''
Else If @FacilityName In (''Tabaka Mission Hospital'')
Set @ParentFacility = ''Tabaka''
Else If @FacilityName = ''St. Joseph Shelter Of Hope''
Set @ParentFacility = ''Voi''
Else If @FacilityName = ''Homa Hills Health Centre''
Set @ParentFacility = ''HomaHills''
Else If @FacilityName = ''St Elizabeth Chiga Health Centre''
Set @ParentFacility = ''Chiga''
Else If @FacilityName In (''St Camillus Karungu'',''Kadem(Nyandema) Disp'',''Mirogi'')
Set @ParentFacility = ''Karungu''
Else If @FacilityName = ''Holy Family Nangina Hospital''
Set @ParentFacility = ''Nangina''
Else If @FacilityName = ''St Monica Hospital''
Set @ParentFacility = ''StMonica''
Else If @FacilityName = ''St. Marys Mumias Hospital''
Set @ParentFacility = ''StMarys''


Else Set @ParentFacility = @FacilityName

Return @ParentFacility
End
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPreARTStatusMOH_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetPreARTStatusMOH_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE Function [dbo].[fn_GetPreARTStatusMOH_IQTools](@PatientPK Int, @toDate datetime) RETURNS VARCHAR(100) AS
BEGIN

Declare @Status as varchar(100)

Select @Status = CASE WHEN b.StartARTDate <= @todate THEN ''A'' 
WHEN d.ExitDate <= @todate THEN SUBSTRING(d.ExitReason,1,1)
WHEN DATEDIFF(dd, c.LA, @todate) BETWEEN 30 AND 90 THEN ''F''
WHEN DATEDIFF(dd, c.LA, @todate) > 90 OR c.PatientPK IS NULL THEN ''L''
ELSE ''V'' END 

 FROM tmp_PatientMaster a
Left JOIN tmp_ARTPatients b ON a.PatientPK = b.PatientPK
LEFT JOIN
(Select a.PatientPK, MAX(a.VisitDate) LV
,  MAX(a.NextAppointmentDate)  LA 
From (Select PatientPK, VisitDate
, MAX(CASE WHEN NextAppointmentDate IS NULL THEN DATEADD(dd,30,VisitDate) ELSE NextAppointmentDate END) AS NextAppointmentDate
FROM tmp_ClinicalEncounters 
GROUP BY PatientPK, VisitDate ) a
Where VisitDate <= @todate
GROUP BY PatientPK
)c ON a.PatientPK = c.PatientPK

LEFT JOIN tmp_LastStatus d ON a.PatientPK = d.PatientPK

Where a.RegistrationAtCCC <= @todate
AND a.PatientPK = @patientPK

RETURN @Status 
END' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPregnancyStatus]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetPregnancyStatus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
Create Function [dbo].[fn_GetPregnancyStatus]( @LMP Datetime, @EDD Datetime, @toDate Datetime) returns int as
Begin
	declare @flag int
	if
	@todate between @LMP and @EDD
	set @flag = 1
	else
	set @flag = 0
	return @flag
end

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRegimenAtMonthX]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetRegimenAtMonthX]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE Function [dbo].[fn_GetRegimenAtMonthX](@PatientPK varchar(100), @Month int)
Returns varchar(100) As
Begin
Declare @Regimen As Varchar(100)
Declare @Termination As Varchar(100);

--With CleanART As (
--Select 
--PatientPK
--,VisitID
--, Regimen 
--, DispenseDate
--, ExpectedReturn
--, RegimenLine
--From (
--Select  
--PatientPK
--,VisitID
--, replace(replace(replace(replace(replace(Drug,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') as Regimen 
--, DispenseDate
--, ExpectedReturn
--, RegimenLine
 
--From tmp_Pharmacy Where TreatmentType = ''ART''
--and len(replace(replace(replace(replace(replace(Drug,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') ) between 11 and 12) a
--Where SUBSTRING(Regimen,0,4)!= SUBSTRING(Regimen,5,3)
--and SUBSTRING(Regimen,0,4) != SUBSTRING(Regimen,9,3)
--and SUBSTRING(Regimen,5,3) != SUBSTRING(Regimen,9,3)
--)

--Select @Regimen = Max(a.Regimen)
--From CleanART a Inner Join tmp_ARTPatients b On a.PatientPK = b.PatientPK 
--Where  
--a.PatientPK = @PatientPK
--And DateDiff(mm,  b.StartARTDate, a.DispenseDate) = @Month

if @Month = 0
Begin 
With CleanART As (
Select 
PatientPK
,VisitID
, Regimen 
, DispenseDate
, ExpectedReturn
, RegimenLine
From (
Select  
PatientPK
,VisitID
, replace(replace(replace(replace(replace(Drug,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') as Regimen 
, DispenseDate
, ExpectedReturn
, RegimenLine
 
From tmp_Pharmacy Where TreatmentType = ''ART''
and len(replace(replace(replace(replace(replace(Drug,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') ) between 11 and 12) a
Where SUBSTRING(Regimen,0,4)!= SUBSTRING(Regimen,5,3)
and SUBSTRING(Regimen,0,4) != SUBSTRING(Regimen,9,3)
and SUBSTRING(Regimen,5,3) != SUBSTRING(Regimen,9,3)
)
Select @Regimen =  a.Regimen From CleanART a Inner Join
(Select PatientPK, MIN(DispenseDate) FirstDispense 
From CleanART Where PatientPK = @PatientPK
Group By PatientPK) b on a.PatientPK = b.PatientPK and a.DispenseDate = b.FirstDispense
End

Else
Begin
With CleanART As (
Select 
PatientPK
,VisitID
, Regimen 
, DispenseDate
, ExpectedReturn
, RegimenLine
From (
Select  
PatientPK
,VisitID
, replace(replace(replace(replace(replace(Drug,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') as Regimen 
, DispenseDate
, ExpectedReturn
, RegimenLine
 
From tmp_Pharmacy Where TreatmentType = ''ART''
and len(replace(replace(replace(replace(replace(Drug,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') ) between 11 and 12) a
Where SUBSTRING(Regimen,0,4)!= SUBSTRING(Regimen,5,3)
and SUBSTRING(Regimen,0,4) != SUBSTRING(Regimen,9,3)
and SUBSTRING(Regimen,5,3) != SUBSTRING(Regimen,9,3)
)
Select @Regimen = Max(a.Regimen) From CleanART a Inner Join
(Select a.PatientPK, Max(a.DispenseDate) LD 
From CleanART a Inner Join tmp_ARTPatients b On a.PatientPK = b.PatientPK  
Where a.PatientPK = @PatientPK And  DateDiff(mm,  b.StartARTDate, a.DispenseDate) Between @Month - 3 And @Month
Group By a.PatientPK) b On a.PatientPK = b.PatientPK And a.DispenseDate = b.LD

--Select @Termination = ExitReason
--From tmp_ARTPatients a
--Where 
--DateDiff(mm,  a.StartARTDate, a.ExitDate) = @Month And a.PatientPK = @PatientPK
End
Return Coalesce(@Termination,@Regimen)


End' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRegimenCode]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetRegimenCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
CREATE FUNCTION [dbo].[fn_GetRegimenCode]
(
@Regimen varchar(30), @Type varchar(10), @Age Decimal
)
RETURNS Varchar(20)
AS
BEGIN
    Declare @RegCode As Varchar(20)
    If (@Type = ''MoH361B'')
	   Begin
	   If(@Age >=15)
		  Begin 
		  If(@Regimen = ''3TC/AZT/NVP'')
		  Set @RegCode = ''AF1A''
		  Else If(@Regimen = ''3TC/AZT/EFV'')
		  Set @RegCode = ''AF1B''
		  Else If(@Regimen = ''3TC/NVP/TDF'')
		  Set @RegCode = ''AF2A''
		  Else If(@Regimen = ''3TC/EFV/TDF'')
		  Set @RegCode = ''AF2B''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/NVP'')
		  Set @RegCode = ''AF3A''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/EFV'')
		  Set @RegCode = ''AF3B''
		  Else If(@Regimen = ''3TC/AZT/LOP'')
		  Set @RegCode = ''AS1A''
		  Else If(@Regimen = ''AZT/DDI/LOP'')
		  Set @RegCode = ''AS1B''
		  Else If(@Regimen = ''3TC/ABC/AZT'')
		  Set @RegCode = ''AS1C''
		  Else If(@Regimen = ''3TC/LOP/TDF'')
		  Set @RegCode = ''AS2A''
		  Else If(@Regimen = ''3TC/ABC/TDF'')
		  Set @RegCode = ''AS2B''
		  Else If(@Regimen = ''3TC/AZT/TDF'')
		  Set @RegCode = ''AS2C''
		  Else If(@Regimen = ''ABC/LOP/TDF'')
		  Set @RegCode = ''AS2D''
		  Else If(@Regimen = ''AZT/LOP/TDF'')
		  Set @RegCode = ''AS2E''
		  Else If(@Regimen = ''ABC/DDI/LOP'')
		  Set @RegCode = ''AS3A''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/LOP'')
		  Set @RegCode = ''AS4A''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/ABC'')
		  Set @RegCode = ''AS4B''
		  Else If(@Regimen = ''3TC/ABC/NVP'')
		  Set @RegCode = ''AO1A''
		  Else If(@Regimen = ''3TC/ABC/EFV'')
		  Set @RegCode = ''AO1B''
		  Else If(@Regimen = ''3TC/ABC/LOP'')
		  Set @RegCode = ''AO1C''
		  Else
		  Set @RegCode=''Other''
		  End
	   If(@Age < 15)
		  Begin
		  If(@Regimen = ''3TC/AZT/NVP'')
		  Set @RegCode = ''CF1A''
		  Else If(@Regimen = ''3TC/AZT/EFV'')
		  Set @RegCode = ''CF1B''
		  Else If(@Regimen = ''3TC/AZT/LOP'')
		  Set @RegCode = ''CF1C''
		  Else If(@Regimen = ''3TC/ABC/NVP'')
		  Set @RegCode = ''CF2A''
		  Else If(@Regimen = ''3TC/ABC/EFV'')
		  Set @RegCode = ''CF2B''
		  Else If(@Regimen = ''3TC/ABC/AZT'')
		  Set @RegCode = ''CF2C''
		  Else If(@Regimen = ''3TC/ABC/LOP'')
		  Set @RegCode = ''CF2D''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/NVP'')
		  Set @RegCode = ''CF3A''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/EFV'')
		  Set @RegCode = ''CF3B''
		  
		  --Else If(@Regimen = ''3TC/AZT/LOP'')
		  --Set @RegCode = ''CS1A''
		  Else If(@Regimen = ''ABC/AZT/LOP'')
		  Set @RegCode = ''CS1B''
		  Else If(@Regimen = ''AZT/DDI/LOP'')
		  Set @RegCode = ''CS1C''
		  --Else If(@Regimen = ''3TC/ABC/LOP'')
		  --Set @RegCode = ''CS2A''
		  Else If(@Regimen = ''ABC/DDI/LOP'')
		  Set @RegCode = ''CS2B''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''3TC/D4T/LOP'')
		  Set @RegCode = ''CS3A''
		  Else If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') = ''ABC/D4T/LOP'')
		  Set @RegCode = ''CS3B''
		  Else If(@Regimen = ''AZT/DDI/NVP'')
		  Set @RegCode = ''CO1A''
		  Else If(@Regimen = ''AZT/DDI/EFV'')
		  Set @RegCode = ''CO1B''
		  
		  Else
		  Set @RegCode = ''Other''
		  End 
	   End
    Return @RegCode	
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRegimenLine]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetRegimenLine]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE Function [dbo].[fn_GetRegimenLine](@Regimen varchar(50))
Returns varchar(20)
as
Begin
Declare @RegimenLine as varchar(20)

If(replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''')  In 
(''3TC/AZT/NVP'',
''3TC/AZT/EFV'',
''3TC/ABC/AZT'',
''3TC/NVP/TDF'',
''3TC/EFV/TDF'',
''3TC/AZT/TDF'',
''3TC/D4T/NVP'',
''3TC/D4T/EFV'',
''3TC/ABC/D4T'',
''3TC/AZT/LOP'',
''3TC/ABC/NVP'',
''3TC/ABC/EFV'',
''3TC/ABC/LOP'',
''EFV/FTC/TDF''))

Set @RegimenLine = ''First Line''

Else If (replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''')  In
(''3TC/AZT/LOP'',
''3TC/ATV/AZT'',
''3TC/LOP/TDF'',
''ABC/LOP/TDF'',
''3TC/ATV/TDF'',
''3TC/ABC/LOP'',
''ABC/DDI/LOP'',
''3TC/D4T/LOP'',
''FTC/LOP/TDF''))

Set @RegimenLine = ''Second Line''

Else If (replace(replace(replace(replace(replace(@Regimen,''30'',''''),''40'',''''),''20'',''''),''15'',''''),''1m'','''') Like
''%SQV%'')
Set @RegimenLine = ''Third Line''

Else Set @RegimenLine = ''Other''

Return @RegimenLine

End
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetStatusAtGivenDate]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStatusAtGivenDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE Function [dbo].[fn_GetStatusAtGivenDate](@PatientPK varchar(100), @date datetime, @StatusOrDate varchar(10))
returns varchar(100)
as 
Begin
Declare @Status as varchar(100)
Declare @EMR as varchar(10)
Select @EMR = PMMS From aa_Database
Set @Status = Null

If(@EMR = ''iqcare'' AND @date <= getdate())
Begin
	If(@StatusOrDate = ''status'')
		Begin
			Select @Status = 
			Case When a.ARTended = 1 AND a.ARTEndDate <= d.LastVisit   Then ''Stop'' Else c.Name End 
			From dtl_PatientCareEnded a Inner Join 
				(Select 
				a.Ptn_Pk	
				, Max (Coalesce(a.CareEndedDate, a.ARTEndDate)) ExitDate
				From dtl_PatientCareEnded a 
				Left Join dtl_patienttrackingcare b On a.ptn_pk = b.ptn_pk and a.trackingid = b.trackingid
				Where (b.ModuleID in(2,203) Or a.ARTEnded = 1) 
				And Coalesce(a.CareEndedDate, a.ARTEndDate) <= @date And
				(a.UpdateDate Is Null Or a.UpdateDate <= @date) And a.Ptn_Pk = @PatientPK
				Group By a.Ptn_Pk) 
			b On a.Ptn_pk = b.Ptn_pk And Coalesce(a.CareEndedDate, a.ARTEndDate) = b.ExitDate

			Left Join
			(Select PatientPK, Max(VisitDate) LastVisit 
			From tmp_ClinicalEncounters a 
			Where a.VisitDate <= @date
			Group By PatientPK) d
			On a.Ptn_Pk = d.PatientPK
	
			Left Join mst_Decode c On a.PatientExitReason = c.ID
			Where a.CareEndedDate >= d.LastVisit or a.ARTended = 1

			If (@Status Is Null)
			Begin
				Select @Status = Case 
				When DateDiff (dd,ER,@date) Between 30 and 90 Then ''Defaulter'' 
				When DateDiff(dd,ER,@date) > 90 Then ''LostND'' Else ''Active'' End 
				From (
				Select PatientPK, Max(ExpectedReturn)ER From tmp_Pharmacy 
				Where PatientPK = @patientPK And DispenseDate<@date 
				AND TreatmentType = ''ART''
				Group By PatientPK)a
			End
		END	
	Else If (@StatusOrDate = ''date'')
		Begin
			Select @Status = 
			Case When a.ARTended = 1 Then a.ARTEndDate Else a.CareEndedDate End 
			From dtl_PatientCareEnded a Inner Join 
				(Select 
				a.Ptn_Pk	
				, Max (Coalesce(a.CareEndedDate, a.ARTEndDate)) ExitDate
				From dtl_PatientCareEnded a 
				Left Join dtl_patienttrackingcare b On a.ptn_pk = b.ptn_pk and a.trackingid = b.trackingid
				Where (b.ModuleID in(2,203) Or a.ARTEnded = 1) 
				And Coalesce(a.CareEndedDate, a.ARTEndDate) <= @date And
				(a.UpdateDate Is Null Or a.UpdateDate <= @date) And a.Ptn_Pk = @PatientPK
				Group By a.Ptn_Pk) 
			b On a.Ptn_pk = b.Ptn_pk And Coalesce(a.CareEndedDate, a.ARTEndDate) = b.ExitDate

			Left Join
			(Select PatientPK, Max(VisitDate) LastVisit 
			From tmp_ClinicalEncounters a 
			Where a.VisitDate <= @date
			Group By PatientPK) d
			On a.Ptn_Pk = d.PatientPK
	
			Left Join mst_Decode c On a.PatientExitReason = c.ID
			Where a.CareEndedDate >= d.LastVisit

			If (@Status Is Null)
			Begin
				Select @Status = Case 
				When DateDiff (dd,ER,@date) Between 30 and 90 Then DateAdd(dd,30,ER)
				When DateDiff(dd,ER,@date) > 90 Then DateAdd(dd,91,ER) Else LastARTDate End 
				From (
				Select PatientPK, Max(ExpectedReturn)ER, Max(DispenseDate) LastARTDate 
				From tmp_Pharmacy 
				Where PatientPK = @patientPK And DispenseDate<@date 
				AND TreatmentType = ''ART''
				Group By PatientPK)a
			End

		End
	End
Else If(@EMR = ''ctc2'')
	Begin
		Select @Status = a.Status 
		From tblStatus a Inner Join
			(Select PatientID, Max(StatusDate)MaxStatusDate 
			From tblStatus Where StatusDate <= @date
			Group By PatientID) b On a.PatientID = b.PatientID And a.StatusDate = b.MaxStatusDate
		Where a.PatientID = @PatientPK
	End
Else
	Begin
		If(@StatusOrDate = ''status'')
			Select @Status = a.ExitReason From tmp_LastStatus a Where a.PatientPK = @PatientPK 
		Else If (@StatusOrDate = ''date'')
			Select @Status = a.ExitDate From tmp_LastStatus a Where a.PatientPK = @PatientPK 
	End

Set @Status = Case When @Status Like ''%Lost to%'' Then ''Lost''
					When @Status Like ''%Dea%'' Then ''Death''
					When @Status Like ''%Transfer%'' Then ''Transfer''
					When @Status Like ''%Stop%'' Then ''Stop''
					Else @Status End
Return @Status	
End

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetStatusMOH_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStatusMOH_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
Create Function [dbo].[fn_GetStatusMOH_IQTools](@PatientPK Int, @toDate datetime) RETURNS VARCHAR(100) AS
BEGIN

Declare @Status as varchar(100)

Select @Status = CASE WHEN b.StartARTDate <= @todate THEN ''A'' 
WHEN d.ExitDate <= @todate THEN SUBSTRING(d.ExitReason,1,1)
WHEN DATEDIFF(dd, c.LA, @todate) > 30 THEN ''F''
ELSE ''V'' END 

 FROM tmp_PatientMaster a
Left JOIN tmp_ARTPatients b ON a.PatientPK = b.PatientPK
LEFT JOIN
(Select a.PatientPK, MAX(a.VisitDate) LV
, CASE WHEN MAX(a.NextAppointmentDate) IS NULL 
THEN MAX(a.VisitDate) ELSE MAX(a.NextAppointmentDate) END AS LA 
From tmp_ClinicalEncounters a
Where VisitDate <= @todate
GROUP BY PatientPK
)c ON a.PatientPK = c.PatientPK

LEFT JOIN tmp_LastStatus d ON a.PatientPK = d.PatientPK

Where a.RegistrationAtCCC <= @todate
AND a.PatientPK = @patientPK

RETURN @Status 
END' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetStore]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStore]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE FUNCTION [dbo].[fn_GetStore](@storeid int, @Num int)

RETURNS varchar(200)

AS
begin
declare @storename varchar(200) , @satellite varchar(200)
set @satellite = (select top 1 FacilityName from IQC_SiteDetails order by FacilityId asc)

-- Satellites
	    declare @store table( id  int identity (1,1) primary key, store varchar(200))      

if   @satellite != ''KNH CCC''
begin  
      if @Num = 1
      begin
      -- The Main Store
       --set @storename = (select name from mst_store where name = (select top 1 FacilityName from IQC_SiteDetails order by FacilityId asc))
      set @storename = (select top 1 name from mst_store where dispensingstore = 1 and deleteflag = 0)
	  end
      
      if @Num = 2
      begin
      -- The receiving Store
       set @storename = (select name from mst_store where CentralStore = 1)
      end
 
      if @Num = 3
	  begin
	   
        
        insert @store(store )
		select Name from mst_store where deleteflag = 0 and name not in ((select name from mst_store where name = 
		(select top 1 FacilityName from IQC_SiteDetails order by FacilityId asc)),''Receiving Store'')

		
		set @storeid = (select id from @store where id = @storeid)

		if @storeid = 1
		begin
			set @storename = (select store from @store where id = 1)
		end
		else if @storeid = 2
		begin
			set @storename = (select store from @store where id = 2)
		end
		else if @storeid = 3
		begin
			set @storename = (select store from @store where id = 3)
		end
		else if @storeid = 4
		begin
			set @storename = (select store from @store where id = 4)
		end
			else if @storeid = 5
		begin
			set @storename = (select store from @store where id = 5)
		end
		else if @storeid = 6
		begin
			set @storename = (select store from @store where id = 6)
		end
		else if @storeid = 7
		begin
			set @storename = (select store from @store where id = 7)
		end
		else if @storeid = 8
		begin
			set @storename = (select store from @store where id = 8)
		end
		else if @storeid = 9
		begin
			set @storename = (select store from @store where id = 9)
		end
        else if @storeid = 10
		begin
			set @storename = (select store from @store where id = 10)
		END
		else if @storeid = 11
		begin
			set @storename = (select store from @store where id = 11)
		END
		else if @storeid = 12
		begin
			set @storename = (select store from @store where id = 12)
		END
		else if @storeid = 13
		begin
			set @storename = (select store from @store where id = 13)
		END
		else if @storeid = 14
		begin
			set @storename = (select store from @store where id = 14)
		END
		else if @storeid = 15
		begin
			set @storename = (select store from @store where id = 15)
		END
		else if @storeid = 16
		begin
			set @storename = (select store from @store where id = 16)
		END
		else if @storeid = 17
		begin
			set @storename = (select store from @store where id = 17)
		END
		else if @storeid = 18
		begin
			set @storename = (select store from @store where id = 18)
		end
   end
end
else if @satellite = ''KNH CCC''
begin
  if @Num = 1
      begin
      -- The Main Store
       set @storename = (select name from mst_store where name = ''CCC Bulk Store'')
      end
      
      if @Num = 2
      begin
      -- The receiving Store
       set @storename = (select name from mst_store where CentralStore = 1)
      end
 
      if @Num = 3
	  begin
        insert @store(store )
		select Name from mst_store where deleteflag = 0 and name not in (''Main Drug Store'', ''CCC Bulk Store'')

		
		set @storeid = (select id from @store where id = @storeid)

		if @storeid = 1
		begin
			set @storename = (select store from @store where id = 1)
		end
		else if @storeid = 2
		begin
			set @storename = (select store from @store where id = 2)
		end
		else if @storeid = 3
		begin
			set @storename = (select store from @store where id = 3)
		end
		else if @storeid = 4
		begin
			set @storename = (select store from @store where id = 4)
		end
			else if @storeid = 5
		begin
			set @storename = (select store from @store where id = 5)
		end
		else if @storeid = 6
		begin
			set @storename = (select store from @store where id = 6)
		end
		else if @storeid = 7
		begin
			set @storename = (select store from @store where id = 7)
		end
		else if @storeid = 8
		begin
			set @storename = (select store from @store where id = 8)
		end
		else if @storeid = 9
		begin
			set @storename = (select store from @store where id = 9)
		end
        else if @storeid = 10
		begin
			set @storename = (select store from @store where id = 10)
		END
		else if @storeid = 11
		begin
			set @storename = (select store from @store where id = 11)
		END
		else if @storeid = 12
		begin
			set @storename = (select store from @store where id = 12)
		END
		else if @storeid = 13
		begin
			set @storename = (select store from @store where id = 13)
		END
		else if @storeid = 14
		begin
			set @storename = (select store from @store where id = 14)
		END
		else if @storeid = 15
		begin
			set @storename = (select store from @store where id = 15)
		END
		else if @storeid = 16
		begin
			set @storename = (select store from @store where id = 16)
		END
		else if @storeid = 17
		begin
			set @storename = (select store from @store where id = 17)
		END
		else if @storeid = 18
		begin
			set @storename = (select store from @store where id = 18)
		end
   end
end
   
   RETURN @storename
END


' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetTestCategory]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetTestCategory]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create Function [dbo].[fn_GetTestCategory](@StartARTDate datetime, @ComparisonDate datetime)
Returns Int
As
Begin

Declare @TestCategory int
Set @TestCategory = FLOOR(CASE WHEN (DATEDIFF(dd, @StartARTDate, @ComparisonDate)%180)/180.0 > 0.67 
THEN ROUND(DATEDIFF(dd, @StartARTDate, @ComparisonDate)/180.0,0) 
WHEN (DATEDIFF(dd, @StartARTDate, @ComparisonDate)%180)/180.0 < 0.17 
Then FLOOR(DATEDIFF(dd, @StartARTDate, @ComparisonDate)/180) ELSE NULL END * 6)
Return @TestCategory
End
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetViralLoadDate]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetViralLoadDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[fn_GetViralLoadDate] (@PatientPK INT, @num INT)

RETURNS DATETIME

AS
BEGIN
	DECLARE @VLDates TABLE( Id  INT IDENTITY(1,1) PRIMARY KEY, VLDate DATETIME)
	DECLARE @VLDate DATETIME
	
	INSERT INTO @VLDates(VLDate )
	SELECT DISTINCT TOP 10 ReportedbyDate FROM dbo.tmp_Labs
	WHERE TestName LIKE ''%viral%'' AND PatientPK = @PatientPK ORDER BY ReportedbyDate DESC
	
	SET @VLDate = (SELECT TOP 1 VLDate FROM @VLDates WHERE id = @num)
	
	RETURN @VLDate
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetVisitDate]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetVisitDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[fn_GetVisitDate] (@PatientPK INT, @num INT)

RETURNS DATETIME

AS
BEGIN
	DECLARE @VisitDates TABLE( Id  INT IDENTITY(1,1) PRIMARY KEY, VisitDate DATETIME)
	DECLARE @VisitDate DATETIME
	
	INSERT INTO @VisitDates(VisitDate )
	SELECT DISTINCT TOP 3  VisitDate FROM dbo.tmp_ClinicalEncounters
	WHERE PatientPK = @PatientPK ORDER BY VisitDate DESC
	
	SET @VisitDate = (SELECT TOP 1 VisitDate FROM @VisitDates WHERE id = @num)
	
	RETURN @VisitDate
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_OIDrugsGetUnitPrice]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_OIDrugsGetUnitPrice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE function [dbo].[fn_OIDrugsGetUnitPrice]  
(  
  @ItemId int 
)  
returns decimal  
as  
Begin  
  declare @UnitPrice decimal  
  --select @UnitPrice = SellingPrice from dtl_stocktransaction where itemid = @ItemId
  
  SELECT @UnitPrice = PurchaseUnitPrice FROM dbo.mst_Drug WHERE Drug_pk = @ItemId
  
  return ISNULL(@UnitPrice, 0)  
End
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_ReOrderRegimens_IQTools]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_ReOrderRegimens_IQTools]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[fn_ReOrderRegimens_IQTools](@Regimen as varchar(100)) 
Returns varchar(100) AS 
BEGIN
Declare @ReturnRegimen as varchar(100)
Select 	@ReturnRegimen =  
		Case  
		When a.[1] > a.[2] And  a.[1] > a.[3] And  a.[2] > a.[3] 
		Then a.[3] + ''/'' +  a.[2] + ''/'' + a.[1]  
		When a.[1] > a.[2] And  a.[1] > a.[3] And  a.[3] > a.[2] 
		Then a.[2] + ''/'' + a.[3] + ''/'' + a.[1]  
		When a.[1] > a.[2] And  a.[3] > a.[1] And  a.[3] > a.[2] 
		Then a.[2] + ''/'' +  a.[1] + ''/'' + a.[3]  
		When a.[2] > a.[1] And  a.[2] > a.[3] And  a.[1] > a.[3]  
		Then a.[3] + ''/'' +  a.[1] + ''/'' + a.[2]  
		When a.[2] > a.[1] And  a.[2] > a.[3] And  a.[3] > a.[1] 
		Then a.[1] + ''/'' +  a.[3] + ''/'' + a.[2]  
		When a.[3] > a.[1] And  a.[3] > a.[2] And  a.[2] > a.[1]
		Then a.[1] + ''/'' +  a.[2] + ''/'' + a.[3]  
		When a.[3] Is Null And a.[1] >  a.[2] 
		Then a.[2] + ''/'' +  a.[1]  
		When a.[3] Is Null And a.[2] >  a.[1] 
		Then a.[1] + ''/'' +  a.[2]		  
		When a.[2] Is Null And a.[1] Is Not Null
		Then a.[1]		  
		Else a.Regimen End 
FROM 
	(
	Select 
	@Regimen Regimen,
	SubString(@Regimen, 0, 4) [1],
	Case
	When CharIndex(''/'', @Regimen) > 0 Then SubString(@Regimen,
	CharIndex(''/'', @Regimen) + 1, 3) End As [2],
	Case
	When CharIndex(''/'', @Regimen, 6) > 0 Then SubString(@Regimen,
	CharIndex(''/'', @Regimen, 6) + 1, 3) Else Null End As [3]
	) a 

IF(@ReturnRegimen = '''') 
BEGIN
Set @ReturnRegimen = NULL
END
Return @ReturnRegimen

END' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_VLTiming]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_VLTiming]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[fn_VLTiming]
(
 @startart datetime, @vldate datetime
)
returns varchar(6) as
begin
 declare @gestagegroup varchar(6)

  set @gestagegroup =
  case
   when datediff(mm, @vldate, @startart)< 20 then ''0-2''
   when datediff(mm, @vldate, @startart) between 20 and 24 then ''2-4''
   when datediff(mm, @vldate, @startart) between 24 and 28 then ''4-6''

  end
 return @gestagegroup
end
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[GetLastDayOfMonth]    Script Date: 3/1/2016 2:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastDayOfMonth]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetLastDayOfMonth]
(
  @date  as Datetime  
)
RETURNS Datetime 
AS
BEGIN
declare @datereturn as datetime
declare @instantdate as datetime
set @instantdate = DATEADD(DAY, -(DAY(@date)), @date)
 IF MONTH(@instantdate) = 1 or MONTH(@instantdate) = 4 or MONTH(@instantdate) = 7 or MONTH(@instantdate)=10
 begin
 set @datereturn = DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@instantdate)+3,0))
 end
 else if MONTH(@instantdate) = 2 or MONTH(@instantdate) = 5 or MONTH(@instantdate) = 8 or MONTH(@instantdate)=11
 begin
 set @datereturn = DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@instantdate)+2,0))
 end
 else
 begin
 set @datereturn  = @instantdate;
 end 
 return @datereturn
 END


' 
END

GO
