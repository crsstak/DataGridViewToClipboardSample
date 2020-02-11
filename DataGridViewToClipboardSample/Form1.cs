using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewToClipboardSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Rows.Add("操作列01", "hoge01_1", "hoge01_2", "hoge01_3", "hoge01_4", "hoge01_5");
            dataGridView1.Rows.Add("操作列02", "hoge02_1", "hoge02_2", "hoge02_3", "hoge02_4", "hoge02_5");
            dataGridView1.Rows.Add("操作列03", "hoge03_1", "hoge03_2", "hoge03_3", "hoge03_4", "hoge03_5");
            dataGridView1.Rows.Add("操作列04", "hoge04_1", "hoge04_2", "hoge04_3", "hoge04_4", "hoge04_5");
            dataGridView1.Rows.Add("操作列05", "hoge05_1", "hoge05_2", "hoge05_3", "hoge05_4", "hoge05_5");
            dataGridView1.Rows.Add("操作列06", "hoge06_1", "hoge06_2", "hoge06_3", "hoge06_4", "hoge06_5");
            dataGridView1.Rows.Add("操作列07", "hoge07_1", "hoge07_2", "hoge07_3", "hoge07_4", "hoge07_5");
            dataGridView1.Rows.Add("操作列08", "hoge08_1", "hoge08_2", "hoge08_3", "hoge08_4", "hoge08_5");
            dataGridView1.Rows.Add("操作列09", "hoge09_1", "hoge09_2", "hoge09_3", "hoge09_4", "hoge09_5");
            dataGridView1.Rows.Add("操作列10", "hoge10_1", "hoge10_2", "hoge10_3", "hoge10_4", "hoge10_5");

            dataGridView1.Rows[0].Selected = true;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 一時的に制御を解除

            // 操作列以外をクリップボードにコピーするため、セル選択モード
            // ※通常時は行全体を選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 全行クリップボードへコピーするため、複数選択可
            // ※通常は単一行のみ選択可
            dataGridView1.MultiSelect = true;

            int index = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell column in row.Cells)
                {
                    // １列目はスキップ
                    if (column.ColumnIndex == 0)
                    {
                        continue;
                    }

                    // 列選択
                    column.Selected = true;
                }

                if (row.Selected)
                {
                    // 選択済みの行を退避
                    index = row.Index;
                }

                row.Selected = true;
            }

            // クリップボードへコピー
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());

            // 単一行のみ、行全体を選択状態に戻す
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // 退避した選択済みの行を設定
            IEnumerable<DataGridViewRow> rows = dataGridView1.Rows.OfType<DataGridViewRow>();
            DataGridViewRow selectedRow = rows.Where(x => x.Index == index).Single();
            selectedRow.Selected = true;
        }
    }
}
