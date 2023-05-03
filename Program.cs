using Parquet;
using Parquet.Schema;
using Table = Parquet.Rows.Table;
using Row = Parquet.Rows.Row;

var table = new Table(
    new DataField<int>("prop1"),
    new DataField<int>("prop2"),
    new StructField("level1",
        new DataField<int>("level1prop1"),
        new StructField("level2",
            new DataField<int>("level2prop1"),
            new ListField("level3",
                new StructField(ListField.ElementName,
                    new DataField<int>("prop1")
                )
            )
        )
    )
);

table.Add(
    0,
    0,
    new Row(
        1,
        new Row(
            2,
            new[]
            {
                new Row(3),
                new Row(3),
                new Row(3),
                new Row(3),
            }
        )
    )
);

table.WriteAsync("test.parquet").GetAwaiter().GetResult();
