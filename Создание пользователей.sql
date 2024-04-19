-- �������� ������������ � ������� �� ������ ������ �� ������� ������������
CREATE USER ReadOnlyUser FOR LOGIN ReadOnlyLogin;
GRANT SELECT ON dbo.������������ TO ReadOnlyUser;

-- �������� ������������ � ������� �� ����������, ��������� � �������� ������ �� ������� ������������
CREATE USER ReadWriteUser FOR LOGIN ReadWriteLogin;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.������������ TO ReadWriteUser;

-- �������� ������������ � ������� �� ������ ������ �� ���� ������
CREATE USER ReadOnlyAllUser FOR LOGIN ReadOnlyAllLogin;
GRANT SELECT ON dbo.������������ TO ReadOnlyAllUser;
GRANT SELECT ON dbo.[��������� ���������] TO ReadOnlyAllUser;
GRANT SELECT ON dbo.[������ ���������] TO ReadOnlyAllUser;
GRANT SELECT ON dbo.���������� TO ReadOnlyAllUser;

-- �������� ������������ � ������� �� ��������� ������ �� ���� ������
CREATE USER ReadWriteAllUser FOR LOGIN ReadWriteAllLogin;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.������������ TO ReadWriteAllUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.[��������� ���������] TO ReadWriteAllUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.[������ ���������] TO ReadWriteAllUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.���������� TO ReadWriteAllUser;