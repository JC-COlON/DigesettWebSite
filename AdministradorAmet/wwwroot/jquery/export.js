window.exportTicketsToPDF = function (tickets) {
    const doc = new jsPDF();

    const columns = [
        { header: 'No. Multa', dataKey: 'ticketId' },
        { header: 'Fecha', dataKey: 'formattedTicketDate' },
        { header: 'Cédula', dataKey: 'identification' },
        { header: 'Estado', dataKey: 'status' },
        { header: 'Pagadas', dataKey: 'paidAmount' },
        { header: 'Pendientes', dataKey: 'pendingAmount' }
    ];

    const rows = tickets.map(t => ({
        ticketId: t.ticketId,
        formattedTicketDate: t.formattedTicketDate,
        identification: t.identification,
        status: t.status === 'Paid' ? 'Pagada' : (t.status === 'pending' ? 'Pendiente' : t.status),
        paidAmount: t.status === 'Paid' ? t.articulo.price.toLocaleString('en-US', { style: 'currency', currency: 'USD' }) : '',
        pendingAmount: t.status === 'pending' ? t.articulo.price.toLocaleString('en-US', { style: 'currency', currency: 'USD' }) : ''
    }));

    doc.text('Reporte Financiero', 14, 20);
    doc.autoTable({
        head: [columns.map(col => col.header)],
        body: rows.map(r => columns.map(col => r[col.dataKey])),
        startY: 30,
        theme: 'grid',
        styles: {
            font: 'helvetica',
            fontSize: 10,
        },
        didDrawPage: function (data) {
            const pageSize = doc.internal.pageSize;
            const pageHeight = pageSize.height || pageSize.getHeight();
            doc.text(`Página ${doc.internal.getNumberOfPages()}`, data.settings.margin.left, pageHeight - 10);
        }
    });

    doc.save('Reporte_Multas.pdf');
};
