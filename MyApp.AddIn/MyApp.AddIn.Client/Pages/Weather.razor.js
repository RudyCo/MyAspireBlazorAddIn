/* Copyright(c) Maarten van Stam. All rights reserved. Licensed under the MIT License. */
/**
 * Basic function to show how to insert a value into cell A1 on the selected Excel worksheet.
 */
export function copyButton(forecasts) {
    return Excel.run(context => {
        let sheet = context.workbook.worksheets.getActiveWorksheet();
        let expensesTable = sheet.tables.add("A1:D1", true /*hasHeaders*/);

        expensesTable.getHeaderRowRange().values = [["Date", "Temp. (C)", "Temp. (F)", "Summary"]];

        expensesTable.rows.add(null /*add rows to the end of the table*/, forecasts);

        if (Office.context.requirements.isSetSupported("ExcelApi", "1.2")) {
            sheet.getUsedRange().format.autofitColumns();
            sheet.getUsedRange().format.autofitRows();
        }

        sheet.activate();

        return context.sync();
    });
}