--if not exists (select * from Usuarios where Cpf='admin') begin
--   insert into Usuarios (Id, Cpf, Nome, Senha, CriadoEm, AtualizadoEm, Status)
--   select NEWID(), 'admin', 'Administrador', '49697cd68df0699f935cae8252025c246aef67ac06a01592bf88a4807d8ddd81', getdate(), getdate(), 1
--end

--declare @id uniqueidentifier
--    set @id  = NEWID()

--if not exists (select * from Perfis where Nome='sysadmin') begin
--   INSERT INTO Perfis ([Id], [Nome], [Permissao], [CriadoEm], [AtualizadoEm], [Status])
--   select '5CD787FE-A15A-4767-B281-4737CD56AC7D', 'sysadmin', 'SysAdmin', getdate(), getdate(), -1
--end

--if not exists (select * from Usuarios where Cpf='admin') begin
--   insert into Usuarios (Id, Cpf, Nome, Senha, CriadoEm, AtualizadoEm, Status, PerfilId)
--   select 'BB27C4E1-F34E-4710-871B-9DC2815F005F', 'admin', 'Administrador', '49697cd68df0699f935cae8252025c246aef67ac06a01592bf88a4807d8ddd81', getdate(), getdate(), 1, '5CD787FE-A15A-4767-B281-4737CD56AC7D'
--end