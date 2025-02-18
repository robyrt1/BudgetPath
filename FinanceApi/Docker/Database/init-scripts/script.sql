IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'finance')
BEGIN
    CREATE DATABASE finance;
END;

use finance;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[EmailLower]  AS (lower([Email])) PERSISTED,
	[PasswordHash] [nvarchar](255) NULL,
	[FirebaseUid] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[AuthProvider] [nvarchar](255) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[EmailLower] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE NONCLUSTERED INDEX [idx_user_email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF
GO
CREATE NONCLUSTERED INDEX [idx_user_email_lower] ON [dbo].[Users]
(
	[EmailLower] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_LoginMethod] CHECK  (([PasswordHash] IS NOT NULL AND [FirebaseUid] IS NULL OR [PasswordHash] IS NULL AND [FirebaseUid] IS NOT NULL))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_LoginMethod]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group_Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Descript] [nvarchar](255) NOT NULL,
	[CREATED_AT] [date] NULL,
	[Type] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Group_Category] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Group_Category] ADD  DEFAULT (getdate()) FOR [CREATED_AT]
GO
ALTER TABLE [dbo].[Group_Category]  WITH CHECK ADD  CONSTRAINT [CHK_GroupCategory_Type] CHECK  (([Type]='INVESTIMENTO' OR [Type]='DESPESA' OR [Type]='RECEITA'))
GO
ALTER TABLE [dbo].[Group_Category] CHECK CONSTRAINT [CHK_GroupCategory_Type]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Descript] [nvarchar](255) NOT NULL,
	[GroupId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Parent]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [GROUP_CATEGORY_FK] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group_Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [GROUP_CATEGORY_FK]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [USER_CATEGORY_FK] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [USER_CATEGORY_FK]
GO


use finance;
go
insert into Group_Category (Id,[Descript]) values (newId(),'INVESTIMENTO');
go
insert into Group_Category (Id,[Descript]) values (newId(),'RECEITA');
go 
insert into Group_Category (Id,[Descript]) values (newId(),'DESPESA');
go


use finance
go
use finance
go
create table Account (
    Id uniqueidentifier not null PRIMARY key DEFAULT NEWID(),
    UserID uniqueidentifier not null,
    Name NVARCHAR(255) not null,
    Balance Decimal(18,2) default 0,
    Type NVARCHAR(255) CHECK(Type in ('Corrente','Poupança')),
    CreateAt DateTime default GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(Id)
);
GO

use finance
go
create table CreditCard (
    Id uniqueidentifier not null PRIMARY key DEFAULT NEWID(),
    AccountId uniqueidentifier not null,
    Name NVARCHAR(255) not null,
    Limit Decimal(18,2) default 0,
    Maturity int not null CHECK (Maturity between 1 and 31),
    Closing int not null CHECK (Closing between 1 and 31),
    FOREIGN key (AccountId) REFERENCES Account(Id)
);


use finance
go
CREATE TABLE Debts (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    AccountId UNIQUEIDENTIFIER NULL,
    CreditCardId UNIQUEIDENTIFIER NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Installments INT DEFAULT 1 CHECK (Installments > 0),
    PaidAmount DECIMAL(18,2) DEFAULT 0,
    RemainingAmount DECIMAL(18,2) DEFAULT 0 ,
    DueDate DATE NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('Pendente', 'Pago', 'Atrasado', 'Parcialmente Pago')) DEFAULT 'Pendente',
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (AccountId) REFERENCES Account(Id),
    FOREIGN KEY (CreditCardId) REFERENCES CreditCard(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

go

CREATE TRIGGER UpdateRemainingAmount ON Debts
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Debts
    SET RemainingAmount = TotalAmount - PaidAmount
    WHERE Id IN (SELECT Id FROM inserted);
END;


CREATE TABLE DebtInstallments (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DebtId UNIQUEIDENTIFIER NOT NULL,
    InstallmentNumber INT NOT NULL CHECK (InstallmentNumber > 0),
    DueDate DATE NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    PaidAmount DECIMAL(18,2) DEFAULT 0,
    Status NVARCHAR(50) CHECK (Status IN ('Pendente', 'Pago', 'Atrasado', 'Parcialmente Pago')) DEFAULT 'Pendente',
    FOREIGN KEY (DebtId) REFERENCES Debts(Id) ON DELETE CASCADE
);

CREATE TABLE Transactions (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    AccountId UNIQUEIDENTIFIER NULL,
    CreditCardId UNIQUEIDENTIFIER NULL,
    DebtId UNIQUEIDENTIFIER NULL, -- Referência para uma dívida (se aplicável)
    InstallmentId UNIQUEIDENTIFIER NULL, -- Referência para uma parcela (se aplicável)
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL, -- Valor pago na transação
    TransactionDate DATE NOT NULL DEFAULT GETDATE(), -- Data da transação
    PaymentMethod NVARCHAR(50) CHECK (PaymentMethod IN ('Dinheiro', 'Cartão', 'Boleto', 'PIX', 'Transferência')) NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('Confirmado', 'Pendente', 'Cancelado')) DEFAULT 'Confirmado',
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (AccountId) REFERENCES Account(Id),
    FOREIGN KEY (CreditCardId) REFERENCES CreditCard(Id),
    FOREIGN KEY (DebtId) REFERENCES Debts(Id) ON DELETE CASCADE,
    FOREIGN KEY (InstallmentId) REFERENCES DebtInstallments(Id) ON DELETE CASCADE,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
go


use finance;
go
INSERT INTO Categories (Id, Descript, GroupId, ParentId) 
VALUES 
(NEWID(), 'Supermercado', (SELECT Id FROM Group_Category WHERE Descript = 'DESPESA'), 
    (SELECT Id FROM Categories WHERE Descript = 'Alimentação')),

(NEWID(), 'Restaurantes', (SELECT Id FROM Group_Category WHERE Descript = 'DESPESA'), 
    (SELECT Id FROM Categories WHERE Descript = 'Alimentação')),

(NEWID(), 'FIIs', (SELECT Id FROM Group_Category WHERE Descript = 'INVESTIMENTO'), 
    (SELECT Id FROM Categories WHERE Descript = 'Investimentos')),

(NEWID(), 'Ações', (SELECT Id FROM Group_Category WHERE Descript = 'INVESTIMENTO'), 
    (SELECT Id FROM Categories WHERE Descript = 'Investimentos'));
go

