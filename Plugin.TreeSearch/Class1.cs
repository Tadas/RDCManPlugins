using RdcMan;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Plugin.TreeSearch
{
    [Export(typeof(IPlugin))]
    public class TreeSearch : IPlugin
    {
        public void OnContextMenu(System.Windows.Forms.ContextMenuStrip contextMenuStrip, RdcTreeNode node)
        {

        }

        public void OnDockServer(ServerBase server)
        {

        }

        public void OnUndockServer(IUndockedServerForm form)
        {

        }

        public void PostLoad(IPluginContext context)
        {
            // Use a random public class to get the assembly that has the private stuff we need
            var ass = Assembly.GetAssembly(typeof(Log));
            var ProgramType = ass.GetType("RdcMan.Program");
            var TheFormProperty = ProgramType.GetProperty("TheForm", BindingFlags.Static | BindingFlags.NonPublic);

            // Since the property is static we don't need an instance to get the value, we can use the type
            var DaForm = TheFormProperty.GetValue(ProgramType, null);

            if (DaForm == null){
                MessageBox.Show("Program.TheForm is null", "PostLoad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var MainFormType = ass.GetType("RdcMan.MainForm");
            var MenuPanelField = MainFormType.GetField("_menuPanel", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            // The field is not static so we need to use the form instance we found in the previous step
            var DaMenuPanel = (Panel)MenuPanelField.GetValue(DaForm);

            if (DaMenuPanel == null){
                MessageBox.Show("MainForm._menuPanel is null", "PostLoad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            TextBox textBox = new TextBox()
            {
                Enabled = true,
                Width = 150,
                Dock = DockStyle.Right,
                Text = "Search query goes here..."
            };
            DaMenuPanel.Controls.Add(textBox);

            
        }

        public void PreLoad(IPluginContext context, XmlNode xmlNode)
        {

        }

        public XmlNode SaveSettings()
        {
            return null;
        }

        public void Shutdown()
        {

        }
    }
}
