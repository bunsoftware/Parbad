﻿// Copyright (c) Parbad. All rights reserved.
// Licensed under the GNU GENERAL PUBLIC License, Version 3.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parbad.Storage.Abstractions;
using Parbad.Storage.EntityFrameworkCore.Context;
using Parbad.Storage.EntityFrameworkCore.Internal;

namespace Parbad.Storage.EntityFrameworkCore
{
    public class EntityFrameworkCoreStorage : IStorage
    {
        public EntityFrameworkCoreStorage(ParbadDataContext context)
        {
            Context = context;
        }

        public virtual IQueryable<Payment> Payments => Context.Payments.AsNoTracking();

        public virtual IQueryable<Transaction> Transactions => Context.Transactions.AsNoTracking();

        protected ParbadDataContext Context { get; }

        public virtual async Task CreatePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            var domain = payment.ToDomain();
            Context.Payments.Add(domain);

            await Context.SaveChangesAsync(cancellationToken);

            Context.Entry(domain).State = EntityState.Detached;

            payment.Id = domain.Id;
        }

        public virtual async Task UpdatePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            var record = await Context
                .Payments
                .AsNoTracking()
                .SingleOrDefaultAsync(model => model.Id == payment.Id, cancellationToken);

            if (record == null) throw new InvalidOperationException($"No payment records found in database with id {payment.Id}");

            DomainMapper.MapPayment(record, payment);
            record.UpdatedOn = DateTime.UtcNow;

            Context.Payments.Update(record);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeletePaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            var record = await Context
                .Payments
                .AsNoTracking()
                .SingleOrDefaultAsync(model => model.Id == payment.Id, cancellationToken);

            if (record == null) throw new InvalidOperationException($"No payment records found in database with id {payment.Id}");

            Context.Payments.Remove(record);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            var domain = transaction.ToDomain();
            Context.Transactions.Add(domain);

            await Context.SaveChangesAsync(cancellationToken);

            transaction.Id = domain.Id;
        }

        public virtual async Task UpdateTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            var record = await Context
                .Transactions
                .AsNoTracking()
                .SingleOrDefaultAsync(model => model.Id == transaction.Id, cancellationToken);

            if (record == null) throw new InvalidOperationException($"No transaction records found in database with id {transaction.Id}");

            DomainMapper.MapTransaction(record, transaction);
            record.UpdatedOn = DateTime.UtcNow;

            Context.Transactions.Update(record);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteTransactionAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            var record = await Context
                .Transactions
                .AsNoTracking()
                .SingleOrDefaultAsync(model => model.Id == transaction.Id, cancellationToken);

            if (record == null) throw new InvalidOperationException($"No transaction records found in database with id {transaction.Id}");

            Context.Transactions.Remove(record);

            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
