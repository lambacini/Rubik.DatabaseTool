using Rubik.DataTools.Fluent;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools
{
    public class DatabaseUtils
    {
        public static Database CompareDatabase(Database fileSchema,Database dbSchema)
        {
            var newDatabase = new Database();
            newDatabase.Name = fileSchema.Name;
            newDatabase.DatabaseVersion = "Database Comparison Result";

            foreach (var user in fileSchema.Users)
            {
                var dbuser = dbSchema.Users.FirstOrDefault(p=>p.Name == user.Name);

                if(dbuser == null)
                {
                    newDatabase.Users.Add(user);
                }
                else
                {
                    Schema newUser = CompareSchema(user, dbuser);
                    newDatabase.Users.Add(newUser);
                }
            }
            return newDatabase;
        }

        private static Schema CompareSchema(Schema fileSchema,Schema dbSchema)
        {
            var schema = new Schema();
            schema.Name = dbSchema.Name;

            foreach (var dbObject in fileSchema.SchemaObjects)
            {
                if (dbObject.GetType() == typeof(Table))
                {
                    Table table = dbSchema.SchemaObjects.FirstOrDefault(p=>p.Name == dbObject.Name) as Table;
                    if(table != null)
                    {
                        var difference = CompareColumns(dbObject as Table, table);
                        if(difference != null)
                            schema.SchemaObjects.Add(difference);
                    }
                    else
                    {
                        (dbObject as Table).GenerateCreateStatment = true;
                        schema.SchemaObjects.Add(dbObject as Table);
                    }
                }
                else if(dbSchema.SchemaObjects.FirstOrDefault(p=>p.Name == dbObject.Name && p.ObjectType == dbObject.ObjectType) == null)
                {
                    schema.SchemaObjects.Add(dbObject);
                }
            }

            return schema;
        }
        private static Table CompareColumns(Table schemaTable,Table dbTable)
        {
            var resultTable = new Table();
            resultTable.Name = schemaTable.Name;
            bool different = false;

            foreach (var column in schemaTable.Columns)
            {
                var result = dbTable.Columns.FirstOrDefault(p => p.Name == column.Name);
                if(result == null)
                {
                    resultTable.Columns.Add(column);
                    different = true;
                }
                else
                {
                    if(result.Nullable != column.Nullable || 
                        result.DataType != column.DataType ||
                        result.ValueLength != column.ValueLength)
                    {
                        column.IsModified = true;
                        resultTable.Columns.Add(column);
                        different = true;
                    }
                }
            }

            return different ? resultTable : null;
        }
    }

    public class DatabaseComparer
    {
        public static DatabaseFactory CompareDatabase(DatabaseFactory fileSchema, DatabaseFactory dbSchema)
        {
            var newDatabase = new DatabaseFactory();
            newDatabase.Name = fileSchema.Name;
            newDatabase.DatabaseVersion = "Database Comparison Result";

            foreach (var user in fileSchema.Users)
            {
                var dbuser = dbSchema.Users.FirstOrDefault(p => p.Name == user.Name);

                if (dbuser == null)
                {
                    newDatabase.Users.Add(user);
                }
                else
                {
                    Schema newUser = CompareSchema(user, dbuser);
                    newDatabase.Users.Add(newUser);
                }
            }
            return newDatabase;
        }

        private static Schema CompareSchema(Schema fileSchema, Schema dbSchema)
        {
            var schema = new Schema();
            schema.Name = dbSchema.Name;

            foreach (var dbObject in fileSchema.SchemaObjects)
            {
                if (dbObject.GetType() == typeof(Table))
                {
                    Table table = dbSchema.SchemaObjects.FirstOrDefault(p => p.Name == dbObject.Name) as Table;
                    if (table != null)
                    {
                        var difference = CompareColumns(dbObject as Table, table);
                        if (difference != null)
                            schema.SchemaObjects.Add(difference);
                    }
                    else
                    {
                        (dbObject as Table).GenerateCreateStatment = true;
                        schema.SchemaObjects.Add(dbObject as Table);
                    }
                }
                else if (dbSchema.SchemaObjects.FirstOrDefault(p => p.Name == dbObject.Name && p.ObjectType == dbObject.ObjectType) == null)
                {
                    schema.SchemaObjects.Add(dbObject);
                }
            }

            return schema;
        }
        private static Table CompareColumns(Table schemaTable, Table dbTable)
        {
            var resultTable = new Table();
            resultTable.Name = schemaTable.Name;
            bool different = false;

            foreach (var column in schemaTable.Columns)
            {
                var result = dbTable.Columns.FirstOrDefault(p => p.Name == column.Name);
                if (result == null)
                {
                    resultTable.Columns.Add(column);
                    different = true;
                }
                else
                {
                    if (result.Nullable != column.Nullable ||
                        result.DataType != column.DataType ||
                        result.ValueLength != column.ValueLength)
                    {
                        column.IsModified = true;
                        resultTable.Columns.Add(column);
                        different = true;
                    }
                }
            }

            return different ? resultTable : null;
        }
    }
}
