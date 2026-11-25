using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ReportingDashboard.Data;

namespace ReportingDashboard.Reports;

// Turns any ReportTable into a PDF document.
public static class ReportPdf
{
    public static byte[] Generate(Report report, ReportTable table, string exportedBy) =>
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.Letter.Landscape());
                page.Margin(36);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Column(column =>
                {
                    column.Item().Text(report.Title).FontSize(18).Bold();
                    column.Item().Text(report.Description);
                    column.Item().Text($"Exported {DateTime.Now:g} by {exportedBy}")
                        .FontSize(8).FontColor(Colors.Grey.Darken1);
                });

                page.Content().PaddingTop(12).Table(t =>
                {
                    t.ColumnsDefinition(columns =>
                    {
                        foreach (var _ in table.Columns)
                        {
                            columns.RelativeColumn();
                        }
                    });

                    t.Header(header =>
                    {
                        for (var i = 0; i < table.Columns.Count; i++)
                        {
                            var column = i;
                            header.Cell()
                                .Background(Colors.Grey.Lighten3)
                                .Element(c => Cell(c, column))
                                .Text(table.Columns[column]).Bold();
                        }
                    });

                    foreach (var row in table.Rows)
                    {
                        AddRow(t, row, bold: false);
                    }
                    AddRow(t, table.Footer, bold: true);
                });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
            });
        }).GeneratePdf();

    private static void AddRow(TableDescriptor table, List<string> values, bool bold)
    {
        for (var i = 0; i < values.Count; i++)
        {
            var column = i;
            var text = table.Cell().Element(c => Cell(c, column)).Text(values[column]);
            if (bold)
            {
                text.Bold();
            }
        }
    }

    // First column is left-aligned (month), the rest are right-aligned amounts.
    private static IContainer Cell(IContainer container, int column)
    {
        container = container
            .BorderBottom(0.5f)
            .BorderColor(Colors.Grey.Lighten2)
            .PaddingVertical(4)
            .PaddingHorizontal(6);
        return column == 0 ? container : container.AlignRight();
    }
}
