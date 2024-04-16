CREATE PROCEDURE AuthenticateUser
    @Login VARCHAR(20),
    @Password VARCHAR(20),
    @IsSuccessful BIT OUTPUT,
    @UserID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Проверяем наличие пользователя в таблице "Групповое посещение"
    SELECT @UserID = Код_пользователя
    FROM [dbo].[Групповое посещение]
    WHERE [Логин] = @Login AND [Пароль] = @Password;

    IF @UserID IS NOT NULL
    BEGIN
        SET @IsSuccessful = 1;
        RETURN;
    END

    -- Если пользователь не найден в таблице "Групповое посещение", проверяем таблицу "Личное посещение"
    SELECT @UserID = Код_пользователя
    FROM [dbo].[Личное посещение]
    WHERE [Логин] = @Login AND [Пароль] = @Password;

    IF @UserID IS NOT NULL
    BEGIN
        SET @IsSuccessful = 1;
        RETURN;
    END

    -- Если пользователь не найден ни в одной из таблиц, возвращаем ошибку
    SET @IsSuccessful = 0;
END;