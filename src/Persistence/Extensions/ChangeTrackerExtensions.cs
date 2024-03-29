﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void SetDeletedProperties(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entries =
                changeTracker.Entries().Where(
                    t=>t.Entity is IEntity &&t.State ==EntityState.Deleted);

            if (entries.Any())
            {
                foreach (EntityEntry entry in entries)
                {
                    IEntity entity =(IEntity)entry.Entity;
                    entity.IsDelete = true;
                    entity.DeletedAt = DateTime.Now;
                    entry.State = EntityState.Modified;
                }
            }
        }

        public static void SetAddedProperties(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entries =
                changeTracker.Entries().Where(
                    t => t.Entity is IEntity &&t.State ==EntityState.Added);

            if (entries.Any())
            {
                foreach (EntityEntry entry in entries)
                {
                    IEntity entity = (IEntity)entry.Entity;
                    entity.CreatedAt = DateTime.Now;
                }
            }
        }

        public static void SetUpdatedroperties(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entries =
                changeTracker.Entries().Where(
                    t => t.Entity is IEntity &&t.State ==EntityState.Modified);

            if (entries.Any())
            {
                foreach (EntityEntry entry in entries)
                {
                    IEntity entity = (IEntity)entry.Entity;
                    entity.UpdatedAt = DateTime.Now;
                }
            }
        }
    }
}
