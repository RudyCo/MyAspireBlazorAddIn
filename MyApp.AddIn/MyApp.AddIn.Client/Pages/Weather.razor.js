/* Copyright(c) Maarten van Stam. All rights reserved. Licensed under the MIT License. */
/**
 * Basic function to show how to insert a value into cell A1 on the selected Excel worksheet.
 */
export function copyButton(forecasts) {
    console.log(forecasts);

    return Excel.run(context => {
        let sheet = context.workbook.worksheets.getActiveWorksheet();
        let expensesTable = sheet.tables.add("A1:D1", true /*hasHeaders*/);
        //expensesTable.name = "ExpensesTable";

        expensesTable.getHeaderRowRange().values = [["Date", "Merchant", "Category", "Amount"]];

        expensesTable.rows.add(null /*add rows to the end of the table*/, [
            ["1/1/2017", "The Phone Company", "Communications", "$120"],
            ["1/2/2017", "Northwind Electric Cars", "Transportation", "$142"],
            ["1/5/2017", "Best For You Organics Company", "Groceries", "$27"],
            ["1/10/2017", "Coho Vineyard", "Restaurant", "$33"],
            ["1/11/2017", "Bellows College", "Education", "$350"],
            ["1/15/2017", "Trey Research", "Other", "$135"],
            ["1/15/2017", "Best For You Organics Company", "Groceries", "$97"]
        ]);

        if (Office.context.requirements.isSetSupported("ExcelApi", "1.2")) {
            sheet.getUsedRange().format.autofitColumns();
            sheet.getUsedRange().format.autofitRows();
        }

        sheet.activate();

        return context.sync();
    });
}
