﻿namespace CashFlowMateus.Application.UseCases.Expenses.DeleteById
{
    public interface IDeleteExpenseUseCase
    {

        Task Execute(long id);

    }
}
