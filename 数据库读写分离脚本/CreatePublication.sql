use [ORMExplore]
exec sp_replicationdboption @dbname = N'ORMExplore', @optname = N'publish', @value = N'true'
GO
-- 添加事务发布
use [ORMExplore]
exec sp_addpublication @publication = N'ORMExplorePublish', @description = N'来自发布服务器“DESKTOP-1210DEL”的数据库“ORMExplore”的事务发布。', @sync_method = N'concurrent', @retention = 0, @allow_push = N'true', @allow_pull = N'true', @allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true', @compress_snapshot = N'false', @ftp_port = 21, @ftp_login = N'anonymous', @allow_subscription_copy = N'false', @add_to_active_directory = N'false', @repl_freq = N'continuous', @status = N'active', @independent_agent = N'true', @immediate_sync = N'true', @allow_sync_tran = N'false', @autogen_sync_procs = N'false', @allow_queued_tran = N'false', @allow_dts = N'false', @replicate_ddl = 1, @allow_initialize_from_backup = N'false', @enabled_for_p2p = N'false', @enabled_for_het_sub = N'false'
GO


exec sp_addpublication_snapshot @publication = N'ORMExplorePublish', @frequency_type = 1, @frequency_interval = 0, @frequency_relative_interval = 0, @frequency_recurrence_factor = 0, @frequency_subday = 0, @frequency_subday_interval = 0, @active_start_time_of_day = 0, @active_end_time_of_day = 235959, @active_start_date = 0, @active_end_date = 0, @job_login = null, @job_password = null, @publisher_security_mode = 0, @publisher_login = N'sa', @publisher_password = N''


use [ORMExplore]
exec sp_addarticle @publication = N'ORMExplorePublish', @article = N'Department', @source_owner = N'dbo', @source_object = N'Department', @type = N'logbased', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x000000000803509F, @identityrangemanagementoption = N'manual', @destination_table = N'Department', @destination_owner = N'dbo', @vertical_partition = N'false', @ins_cmd = N'CALL sp_MSins_dboDepartment', @del_cmd = N'CALL sp_MSdel_dboDepartment', @upd_cmd = N'SCALL sp_MSupd_dboDepartment'
GO




use [ORMExplore]
exec sp_addarticle @publication = N'ORMExplorePublish', @article = N'User', @source_owner = N'dbo', @source_object = N'User', @type = N'logbased', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x000000000803509F, @identityrangemanagementoption = N'manual', @destination_table = N'User', @destination_owner = N'dbo', @vertical_partition = N'false', @ins_cmd = N'CALL sp_MSins_dboUser', @del_cmd = N'CALL sp_MSdel_dboUser', @upd_cmd = N'SCALL sp_MSupd_dboUser'
GO




