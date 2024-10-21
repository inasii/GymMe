using GymMePSD.dataSet;
using GymMePSD.Model;
using GymMePSD.report;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.handler;
using WebApplication2.module;

namespace GymMePSD.Views
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bikin report yang baru

                CrystalReport1 report1 = new CrystalReport1();

                // Set report source dari viewer

                CrystalReportViewer1.ReportSource = report1; //nanti report source yang kita liat hasil dari report yang di atas 

                // Ambil data headers

                response<List<TransactionHeader>> response = TransactionHandlers.getAllofHeader(); // TransactionHandlers.getAllofHeader() dipanggil trus hasilnya disimpan di dalam objek response.

                if (response.isSuccess) //ini kalo pengambilan datanya berhasil, maka - 
                {
                    List<TransactionHeader> headers = response.resultData; // - daftar TransactionHeader diakses melalui properti "resultData" dan dipake sebagai sumber data untuk report.

                    DataSet1 data = GetDataSet(response); //GetDataSet ini bakal nerima list dari si "response" nya, yang menyimpan hasil dari TransactionHandlers.getAllofHeader()


                    // Set data source untuk report
                    report1.SetDataSource(data);

                }

                else 
                {
                    LblError.Text = response.Message;
                    LblError.Visible = true;
                }

                // Membentuk table dan data, kenapa pake dataset? karna reports hanya akan menerima dataset



            }
        }

        private DataSet1 GetDataSet(response<List<TransactionHeader>> headers)
        {
            DataSet1 data = new DataSet1(); //ngebentuk data baru

            //membuat table variable untuk table header dan detail di file report nya

            var headerTable = data.TransactionHeader; //ini tuh gimana caranya si datasetnya bisa dapet si transactionsHeader nya, karna di dataset kita udah masang transactionsHeader dan transactionDetail nya, ini klo datasetnya gada, kita gabisa ngakses
            var detailTable = data.TransactionDetail;

            //iterasi 2D array ibaratnya, soalnya bakal nge for loop 2 kali di headerTable sama headerDetail/detailTable(gatau yg bener yg mana, keknya yg opsi kedua)

            foreach (TransactionHeader h in headers.resultData)
            {
                //variable baru untuk simpen row baru

                var headerRow = headerTable.NewRow();

                //nge set column (secara manual), mksdnya kan si headerRow punya 4 kolom, "TransactionID, UserID, TransactionDate, Status"

                headerRow["TransactionID"] = h.TransactionID;
                headerRow["UserID"] = h.UserID;
                headerRow["TransactionDate"] = h.TransactionDate;
                headerRow["Status"] = h.Status;

                //tambahkan row ke tablenya
                headerTable.Rows.Add(headerRow);

                //iterasi ke detail dari headernya
                foreach (TransactionDetail d in h.TransactionDetails)
                {
                    var detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = d.TransactionID;
                    detailRow["SupplementID"] = d.SupplementID;
                    detailRow["Quantity"] = d.Quantity;

                    detailTable.Rows.Add(detailRow);
                }

            }

            return data;

        }
    }
}