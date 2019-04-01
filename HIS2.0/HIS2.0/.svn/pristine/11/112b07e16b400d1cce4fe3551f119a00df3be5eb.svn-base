IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'Vi_Zy_Byj' 
	   AND 	  type = 'V')
  drop view Vi_Zy_Byj
go 
CREATE VIEW "Vi_Zy_Byj" AS 
select id, HsptCd, DptmtCd, WardCd, DataClsf, InOutClsf, OrderDt, OrderDtm, 
	convert(varchar(50),OrderNum)+TakeDt OrderNum, 
	RoomNum, PtntNm, PtntNum, Sex, DoctorNm, Birthday, PtntAddr, PtntTel, MedCd, 
	MedNm, MedNote, MedSpec, MedUnit, UseAtcYn, DoseList, TakeDays, TakeDt, 
	XmlFlag, DrtsCd, inpatientID, groupID, fybid, yfid, DrtsCd2
from zy_fy_byj

/*
Modify By Tany 2015-03-19 改变OrderNum，由OrderNum+TakeDays组合
*/





