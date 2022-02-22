using System.ComponentModel;
using System.Text;
using System.Text.Json;
using NMaier.PlaneDB;

namespace testTools
{
    public partial class Form1 : Form
    {
    private static  PlaneDBOptions planeDBOptions = new PlaneDBOptions().EnableCompression();
    private List<string> strlist = new List<string>();
    private StringBuilder sb=new StringBuilder();
    private PlaneDB db;
    public Form1()
        {
            InitializeComponent();
      Control.CheckForIllegalCrossThreadCalls = false;
      db = new PlaneDB(new DirectoryInfo("E:\\opt\\data\\testdb"), FileMode.OpenOrCreate, planeDBOptions);
    }
    private void insertData( threadParams param,PlaneDB db)
    {
      try {
        string str = String.Format("{0}-first:{1},last:{2}", System.Threading.Thread.CurrentThread.ManagedThreadId, param.from, param.last);
        strlist.Add(str);
        for (var i = param.from; i < param.last; ++i) {
          var k = Encoding.UTF8.GetBytes(i.ToString());
          var data = new testData(i);
           str= data.ToString();
          var v = Encoding.UTF8.GetBytes(str);
       //  db.Add(k, v);
          if (i % 10000 == 0) {
            {
              this.BeginInvoke(new refreshDisp(refresh));
            }
          }
           db.AddOrUpdate(k, v, (byte[] f1, byte[] f2) => { return f2; });
        }

      }
      catch (Exception ex) {
        strlist.Add(ex.ToString());
      }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      textBox2.Text = "";
      DateTime dtstart = System.DateTime.Now;
      var tcs = new TaskCompletionSource();
      var tasks = new List<Task>();
      long onetaskcount = long.Parse(textBox1.Text);


      for (var taski = 0; taski <1; taski++) {
        threadParams param = new threadParams(taski * onetaskcount, (taski + 1) * onetaskcount);
        tasks.Add(Task.Run(() => {
          insertData(param, db);

        }));
      }

      Task.WaitAll(tasks.ToArray());
      DateTime dtend = System.DateTime.Now;
      textBox2.Text = (dtend - dtstart).TotalSeconds.ToString();
      MessageBox.Show("ok");
    }

    private void refresh() {
      textBox3.Text = String.Join(Environment.NewLine, strlist);
      label1.Text = db.Count.ToString();
    }
    delegate void refreshDisp();//Î¯ÍÐ
    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {

    
    }


  }

  public class threadParams
  {
    public long from;
    public long last;
    public threadParams(long f, long t)
    {
      this.from = f;
      this.last = t;
    }
  }
}