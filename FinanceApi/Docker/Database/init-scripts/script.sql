IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'finance')
BEGIN
    CREATE DATABASE finance;
END;
;


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



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[DescriptionLower]  AS (lower([Description])) PERSISTED,
	[UserId] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PaymentMethod] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF
GO
CREATE NONCLUSTERED INDEX [idx_payment_method_desc_lower] ON [dbo].[PaymentMethod]
(
	[DescriptionLower] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PaymentMethod] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PaymentMethod]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO


insert into PaymentMethod(Description) values('Pix');
insert into PaymentMethod(Description) values('Debito em Conta');
insert into PaymentMethod(Description) values('Transferencia');
insert into PaymentMethod(Description) values('Crédito');
insert into PaymentMethod(Description) values('Boleto');
insert into PaymentMethod(Description) values('Dividendos em Conta');



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Balance] [decimal](18, 2) NULL,
	[Type] [nvarchar](255) NULL,
	[CreateAt] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD CHECK  (([Type]='Poupança' OR [Type]='Corrente'))
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCard](
	[Id] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Limit] [decimal](18, 2) NULL,
	[Maturity] [int] NOT NULL,
	[Closing] [int] NOT NULL,
	[AvailableBalance] [decimal](18, 2) NOT NULL,
	[InvoiceAmount] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CreditCard] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CreditCard] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[CreditCard] ADD  DEFAULT ((0)) FOR [Limit]
GO
ALTER TABLE [dbo].[CreditCard] ADD  DEFAULT ((0)) FOR [AvailableBalance]
GO
ALTER TABLE [dbo].[CreditCard] ADD  DEFAULT ((0)) FOR [InvoiceAmount]
GO
ALTER TABLE [dbo].[CreditCard]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[CreditCard]  WITH CHECK ADD CHECK  (([Closing]>=(1) AND [Closing]<=(31)))
GO
ALTER TABLE [dbo].[CreditCard]  WITH CHECK ADD CHECK  (([Maturity]>=(1) AND [Maturity]<=(31)))
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debts](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NULL,
	[CreditCardId] [uniqueidentifier] NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Installments] [int] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[RemainingAmount] [decimal](18, 2) NULL,
	[DueDate] [date] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Debts] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Debts] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Debts] ADD  DEFAULT ((1)) FOR [Installments]
GO
ALTER TABLE [dbo].[Debts] ADD  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[Debts] ADD  DEFAULT ((0)) FOR [RemainingAmount]
GO
ALTER TABLE [dbo].[Debts] ADD  DEFAULT ('Pendente') FOR [Status]
GO
ALTER TABLE [dbo].[Debts] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([Id])
GO
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD CHECK  (([Installments]>(0)))
GO
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD CHECK  (([Status]='Parcialmente Pago' OR [Status]='Atrasado' OR [Status]='Pago' OR [Status]='Pendente'))
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsertDebtInstallments]
ON [dbo].[Debts]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @DebtId UNIQUEIDENTIFIER;
    DECLARE @Installments INT;
    DECLARE @TotalAmount DECIMAL(18,2);
    DECLARE @DueDate DATE;
    DECLARE @InstallmentNumber INT;
    DECLARE @Year INT;
    DECLARE @Month INT;
    
    DECLARE debt_cursor CURSOR FOR
    SELECT Id, Installments, TotalAmount, DueDate FROM inserted;
    
    OPEN debt_cursor;
    FETCH NEXT FROM debt_cursor INTO @DebtId, @Installments, @TotalAmount, @DueDate;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @InstallmentNumber = 1;
        WHILE @InstallmentNumber <= @Installments
        BEGIN
            -- Calcular a data de vencimento da parcela
            SET @Year = YEAR(DATEADD(MONTH, @InstallmentNumber - 1, @DueDate));
            SET @Month = MONTH(DATEADD(MONTH, @InstallmentNumber - 1, @DueDate));
            
            -- Inserir a parcela
            INSERT INTO DebtInstallments (DebtId, InstallmentNumber, DueDate, Amount, PaidAmount, Status)
            VALUES (
                @DebtId,
                @InstallmentNumber,
                DATEFROMPARTS(@Year, @Month, 18),  -- Calcula a data de vencimento corretamente, incluindo mudança de ano
                @TotalAmount / @Installments,
                0,
                'Pendente'
            );
            
            -- Avançar para a próxima parcela
            SET @InstallmentNumber = @InstallmentNumber + 1;
        END;
        
        FETCH NEXT FROM debt_cursor INTO @DebtId, @Installments, @TotalAmount, @DueDate;
    END;
    
    CLOSE debt_cursor;
    DEALLOCATE debt_cursor;
END;
GO
ALTER TABLE [dbo].[Debts] ENABLE TRIGGER [InsertDebtInstallments]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[UpdateRemainingAmount]
ON [dbo].[Debts]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Debts
    SET RemainingAmount = TotalAmount - PaidAmount
    WHERE Id IN (SELECT Id FROM inserted);
END;


DROP TRIGGER InsertDebtInstallments;

SELECT name 
FROM sys.triggers 
WHERE name = 'InsertDebtInstallments';

GO
ALTER TABLE [dbo].[Debts] ENABLE TRIGGER [UpdateRemainingAmount]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebtInstallments](
	[Id] [uniqueidentifier] NOT NULL,
	[DebtId] [uniqueidentifier] NOT NULL,
	[InstallmentNumber] [int] NOT NULL,
	[DueDate] [date] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DebtInstallments] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DebtInstallments] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DebtInstallments] ADD  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[DebtInstallments] ADD  DEFAULT ('Pendente') FOR [Status]
GO
ALTER TABLE [dbo].[DebtInstallments]  WITH CHECK ADD FOREIGN KEY([DebtId])
REFERENCES [dbo].[Debts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DebtInstallments]  WITH CHECK ADD CHECK  (([InstallmentNumber]>(0)))
GO
ALTER TABLE [dbo].[DebtInstallments]  WITH CHECK ADD CHECK  (([Status]='Parcialmente Pago' OR [Status]='Atrasado' OR [Status]='Pago' OR [Status]='Pendente'))
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingReimbursements](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Withdrawal_date] [datetime] NOT NULL,
	[Withdrawal_amount] [decimal](10, 2) NOT NULL,
	[Expected_repayment_date] [date] NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[Created_at] [datetime] NOT NULL,
	[Updated_at] [datetime] NULL,
	[AccountId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PendingReimbursements] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PendingReimbursements] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PendingReimbursements] ADD  DEFAULT (getdate()) FOR [Withdrawal_date]
GO
ALTER TABLE [dbo].[PendingReimbursements] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[PendingReimbursements]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PendingReimbursements]  WITH CHECK ADD  CONSTRAINT [FK_PendingReimbursements_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[PendingReimbursements] CHECK CONSTRAINT [FK_PendingReimbursements_Account]
GO
ALTER TABLE [dbo].[PendingReimbursements]  WITH CHECK ADD CHECK  (([status]='paid' OR [status]='pending'))
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getDescriptionGroupByCategory](@CategoryId UNIQUEIDENTIFIER)
RETURNS NVARCHAR(255)
WITH EXECUTE AS CALLER
AS 
BEGIN
    DECLARE @Description NVARCHAR(255);

    select @Description = Descript from Group_Category
    where Id = (
        select GroupId from Categories where Id = @CategoryId
    );

    return @Description;
END;
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NULL,
	[CreditCardId] [uniqueidentifier] NULL,
	[DebtId] [uniqueidentifier] NULL,
	[InstallmentId] [uniqueidentifier] NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT ('Confirmado') FOR [Status]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([Id])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([DebtId])
REFERENCES [dbo].[Debts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([InstallmentId])
REFERENCES [dbo].[DebtInstallments] ([Id])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethod] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD CHECK  (([Status]='Cancelado' OR [Status]='Pendente' OR [Status]='Confirmado'))
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TransactionsAfter] 
ON [dbo].[Transactions]
AFTER INSERT 
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AccountId UNIQUEIDENTIFIER;
    DECLARE @DebtId UNIQUEIDENTIFIER;
    DECLARE @CategoryId UNIQUEIDENTIFIER;
    DECLARE @UserId UNIQUEIDENTIFIER;
    DECLARE @CreditCardId UNIQUEIDENTIFIER;
    DECLARE @Amount DECIMAL(18,2);
    DECLARE @Status NVARCHAR(50);
    DECLARE @Balance DECIMAL(18,2);
    DECLARE @AvailableBalance DECIMAL(18,2);
    DECLARE @InvoiceAmount DECIMAL(18,2);
    DECLARE @DescriptionGroup NVARCHAR(255);

    -- Declaração do cursor
    DECLARE insert_cursor CURSOR FOR
    SELECT DebtId, AccountId, CategoryId, Amount, [Status], UserId, CreditCardId 
    FROM inserted;

    OPEN insert_cursor;

    FETCH NEXT FROM insert_cursor 
    INTO @DebtId, @AccountId, @CategoryId, @Amount, @Status, @UserId, @CreditCardId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Obtendo a descrição do grupo da categoria
        SELECT @DescriptionGroup = dbo.getDescriptionGroupByCategory(@CategoryId);

        IF @Status = 'Confirmado'
        BEGIN
            -- Se for RECEITA, garantir que será SOMADO ao saldo da conta
            IF @DescriptionGroup = 'RECEITA' AND @AccountId IS NOT NULL
            BEGIN
                SELECT @Balance = Balance FROM dbo.Account WHERE Id = @AccountId;
                UPDATE dbo.Account 
                SET Balance = @Balance + ABS(@Amount)  -- Garante soma mesmo que @Amount seja negativo
                WHERE Id = @AccountId;
            END
            -- Se for DESPESA, garantir que será SUBTRAÍDO do saldo da conta
            ELSE IF @DescriptionGroup = 'DESPESA' AND @AccountId IS NOT NULL
            BEGIN
                SELECT @Balance = Balance FROM dbo.Account WHERE Id = @AccountId;
                UPDATE dbo.Account 
                SET Balance = @Balance - ABS(@Amount)  -- Garante subtração mesmo que @Amount seja positivo
                WHERE Id = @AccountId;
            END
            -- Se for transação no cartão de crédito
            ELSE IF @CreditCardId IS NOT NULL and  @AccountId IS  NULL
            BEGIN
                SELECT @AvailableBalance = AvailableBalance, @InvoiceAmount = InvoiceAmount 
                FROM dbo.CreditCard 
                WHERE Id = @CreditCardId;

                -- Se for uma despesa no cartão (valor negativo)
                IF @DescriptionGroup = 'DESPESA'
                BEGIN
                    UPDATE dbo.CreditCard 
                    SET AvailableBalance = @AvailableBalance - ABS(@Amount),  -- Reduz saldo disponível
                        InvoiceAmount = @InvoiceAmount + ABS(@Amount)  -- Aumenta a fatura
                    WHERE Id = @CreditCardId;
                END
                -- Se for uma receita no cartão (valor positivo)
                ELSE IF @DescriptionGroup = 'RECEITA'
                BEGIN
                    UPDATE dbo.CreditCard 
                    SET AvailableBalance = @AvailableBalance + ABS(@Amount)  -- Aumenta saldo disponível
                    WHERE Id = @CreditCardId;
                END
            END
        END

        -- Próximo registro do cursor
        FETCH NEXT FROM insert_cursor 
        INTO @DebtId, @AccountId, @CategoryId, @Amount, @Status, @UserId, @CreditCardId;
    END;

    -- Fecha e desaloca o cursor
    CLOSE insert_cursor;
    DEALLOCATE insert_cursor;
END;
GO
ALTER TABLE [dbo].[Transactions] ENABLE TRIGGER [TransactionsAfter]
GO
