-- Создание пользователя с правами на чтение данных из таблицы Пользователи
CREATE USER ReadOnlyUser FOR LOGIN ReadOnlyLogin;
GRANT SELECT ON dbo.Пользователи TO ReadOnlyUser;

-- Создание пользователя с правами на добавление, изменение и удаление данных из таблицы Пользователи
CREATE USER ReadWriteUser FOR LOGIN ReadWriteLogin;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Пользователи TO ReadWriteUser;

-- Создание пользователя с правами на чтение данных из всех таблиц
CREATE USER ReadOnlyAllUser FOR LOGIN ReadOnlyAllLogin;
GRANT SELECT ON dbo.Пользователи TO ReadOnlyAllUser;
GRANT SELECT ON dbo.[Групповое посещение] TO ReadOnlyAllUser;
GRANT SELECT ON dbo.[Личное посещение] TO ReadOnlyAllUser;
GRANT SELECT ON dbo.Сотрудники TO ReadOnlyAllUser;

-- Создание пользователя с правами на изменение данных из всех таблиц
CREATE USER ReadWriteAllUser FOR LOGIN ReadWriteAllLogin;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Пользователи TO ReadWriteAllUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.[Групповое посещение] TO ReadWriteAllUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.[Личное посещение] TO ReadWriteAllUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Сотрудники TO ReadWriteAllUser;