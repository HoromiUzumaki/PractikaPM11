CREATE PROCEDURE [dbo].[RegisterUser]
    @LastName VARCHAR(30),
    @FirstName VARCHAR(30),
    @MiddleName VARCHAR(30),
    @BirthDate DATE,
    @PassportSeries VARCHAR(4),
    @PassportNumber VARCHAR(6),
    @PhoneNumber VARCHAR(20),
    @Email VARCHAR(30),
    @Login VARCHAR(20),
    @Password VARCHAR(20),
    @Purpose VARCHAR(40)
AS
BEGIN
    SET NOCOUNT ON;

    -- Регистрация пользователя в таблице Пользователи
    INSERT INTO [Хранитель ПРО Кротова].[dbo].[Пользователи] ([Фамилия], [Имя], [Отчество], [Дата_рождения], [Серия_паспорта], [Номер_паспорта], [Номер_телефона], [Email])
    VALUES (@LastName, @FirstName, @MiddleName, @BirthDate, @PassportSeries, @PassportNumber, @PhoneNumber, @Email);

    -- Получение ID нового пользователя
    DECLARE @UserID INT;
    SET @UserID = SCOPE_IDENTITY();

    -- Регистрация пропуска пользователя в таблице Пропуск
    INSERT INTO [Хранитель ПРО Кротова].[dbo].[Пропуск] ([Код_заявки], [Цель_посещения])
    VALUES (1, @Purpose);

    -- Получение ID нового пропуска
    DECLARE @PassID INT;
    SET @PassID = SCOPE_IDENTITY();

    -- Регистрация личного посещения пользователя в таблице Личное посещение
    INSERT INTO [Хранитель ПРО Кротова].[dbo].[Личное посещение] ([Логин], [Пароль], [Назначение], [Код_пользователя], [Код_пропуска])
    VALUES (@Login, @Password, @Purpose, @UserID, @PassID);
END;
