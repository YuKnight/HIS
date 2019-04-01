
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_ypcj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_ypcj
GO 
CREATE PROCEDURE sp_yp_ypcj
(
	@CJID INTEGER ,
	@GGID INT,
	@N_YPLX INT,
	@N_YPZLX INT,
	@S_YPJX VARCHAR(50),
	@S_YPPM VARCHAR(100),
	@S_YPSPM VARCHAR(100),
	@S_YPSPMBZ VARCHAR(100),
	@S_YPGG VARCHAR(50),
	@S_SCCJ VARCHAR(100),
	@S_YPDW VARCHAR(10), 
	@TXM VARCHAR(50),  
	@SCCJ INTEGER ,
	@ZBJ DECIMAL(12,4) ,
	@PFJ DECIMAL(12,4) ,
	@LSJ DECIMAL(12,4) ,
	@PZWH VARCHAR(50),
	@YXQ INTEGER,
	@YBLX VARCHAR(20),
	@ZFBL DECIMAL(5,3)  ,
	@MRKL DECIMAL(5,3)  ,
	@MRJJ DECIMAL(12,4),
	@BDELETE SMALLINT  ,
	@ZBZT INTEGER  ,
	@ZBDW VARCHAR(100),
	@ZBQH VARCHAR(50),
	@BZ VARCHAR(200),
	@ZGLSJ DECIMAL(12,4),
	@YLFL BIGINT,
	@S_YPYWM VARCHAR(100),
	@shh varchar(20),
	@Newcjid int output,
	@ERR_CODE INTEGER  output,
    @ERR_TEXT VARCHAR(100)  output  ,
    @cglsh varchar(100),
    @MRGHDW INT,
    @FKBL decimal(15,4),
    @BHTDW BIGINT 
)
as


 declare @yplx int

 declare @yshh varchar(15) --原货号

  
 SET @ERR_CODE=-1
 set @newcjid=0
 begin

 IF @sccj=0 
 begin
      	set @err_text='生产厂家必填'
	return
 end 
   
 if @ggid<=0 
 begin
     	set @err_text='规格ID不能为零,请和管理员联系'
	return   
 end
  
  if @lsj=0 
 begin
    	set @err_text='请输入零售价'
	return
 end
  

   
   if @cjid=0 
   begin
	set @err_text='插入药品厂家信息'
       	insert into yp_ypcjd(ggid,shh,n_yplx,n_ypzlx,s_ypjx,s_yppm,s_ypspm,s_ypspmbz,s_ypgg,s_sccj,s_ypdw,txm,sccj,zbj,pfj,lsj,pzwh,yxq,yblx,zfbl,mrkl,mrjj,bdelete,zbzt,zbdw,zbqh,bz,zglsj,djsj,S_YPYWM,cglsh,MRGHDW,FKBL,BHTDW)
	  values (@ggid,@shh,@n_yplx,@n_ypzlx,@s_ypjx,@s_yppm,@s_ypspm,@s_ypspmbz,@s_ypgg,@s_sccj,@s_ypdw,@txm,@sccj,@zbj,@pfj,@lsj,@pzwh,@yxq,@yblx,@zfbl,@mrkl,@mrjj,@bdelete,@zbzt,@zbdw,@zbqh,@bz,@zglsj,getdate(),@S_YPYWM,@cglsh,@MRGHDW,@FKBL,@BHTDW)
	 
	 if @@ROWCOUNT=0 
         begin
	      	set @err_text='插入药品厂家信息没有成功，影响到数据库0行'
		return
	 end
	  
	 set @Newcjid=@@IDENTITY
	 if @Newcjid<=0 
	 begin
		  set @err_text='厂家ID为零，数据库发生错误'
		  return      
	 end 

	  set @err_text='已成功插入药品厂家信息'
                  
   end
   
   if @cjid>0 
      begin
      	  set @err_text='更新药品厂家信息'
	 
       	update yp_ypcjd set shh=@shh,n_yplx=@n_yplx,n_ypzlx=@n_ypzlx,s_ypjx=@s_ypjx,s_yppm=@s_yppm,s_ypspm=@s_ypspm,
			s_ypspmbz=@s_ypspmbz,s_ypgg=@s_ypgg,s_sccj=@s_sccj,s_ypdw=@s_ypdw,txm=@txm,sccj=@sccj,zbj=@zbj,pfj=@pfj,lsj=@lsj,
			pzwh=@pzwh,yxq=@yxq,yblx=@yblx,zfbl=@zfbl,mrkl=@mrkl,mrjj=@mrjj,bdelete=@bdelete,
			zbzt=@zbzt,zbdw=@zbdw,zbqh=@zbqh,bz=@bz,zglsj=@zglsj,S_YPYWM=@S_YPYWM,cglsh=@cglsh,MRGHDW=@MRGHDW,FKBL=@FKBL,
			bhtdw=@BHTDW
		        where cjid=@cjid
	  if @@ROWCOUNT=0
          begin
	        set @err_text='更新药品厂家信息没有成功，影响到数据库0行'
		return
	  end 

	  set @err_text='已成功更新药品厂家信息'
	      
	  set @newcjid=@cjid
      end


/*
	--重新更新货号
	declare @yphh varchar(10)--药品类型编号
	declare @hwbh varchar(10) --药理分类货位编号
	declare @shh varchar(15)  --新货号
	declare @cjbh varchar(10) --厂家编号 如.1
        declare @cjjsq int	  --厂家计算器
	declare @t1_cjid int
	set @cjjsq=0

	set @yphh=(select coalesce(yphh,'') from yp_yplx where id=@n_yplx)
	SET @HWBH=(select coalesce(hwbh,'')  from yp_ylfl where id=@ylfl)
	SET @yphh=coalesce(@yphh,'')
	SET @HWBH=coalesce(@HWBH,'')
        
	if  rtrim(@hwbh)=''
		SET @shh=(select (rtrim(@yphh) +coalesce(hwjxbm,'')+rtrim(@hwbh)+''+rtrim(hhjsq)) as yphh  from yp_ypggd where ggid=@ggid )
	else
		SET @shh=(select (rtrim(@yphh) +coalesce(hwjxbm,'')+rtrim(@hwbh)+'_'+rtrim(hhjsq)) as yphh  from yp_ypggd where ggid=@ggid )

	 if rtrim(@shh)='' 
	 begin
	    set @err_text='产生药品货号时遇到错误'
	    return 
	 end

	declare t1 cursor local for select cjid from yp_ypcjd where ggid=@ggid order by cjid
	open  t1
	fetch next from t1 into @t1_cjid
	while @@FETCH_STATUS=0
	begin
		set @cjjsq=@cjjsq+1;
		set @cjbh='.'+cast(@cjjsq as varchar(2))
		update yp_ypcjd set shh=rtrim(@shh)+@cjbh where cjid=@t1_cjid
		
		fetch next from t1 into @t1_cjid
	end
	--重新更新货号
*/
        set @err_code=0;       

end 
go


