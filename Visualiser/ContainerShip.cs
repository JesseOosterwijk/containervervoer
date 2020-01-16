using System;
using System.Collections.Generic;
using ContainerVervoer;
using System.Windows.Forms;
using System.Linq;

namespace Visualiser
{
    public partial class ContainerShip : Form
    {
        private readonly List<Container> _containerList = new List<Container>();
        private readonly List<Ship> _shipList = new List<Ship>();

        public ContainerShip()
        {
            InitializeComponent();
        }

        private void ShowLoadedContainers(List<Container> loadedContainerList)
        {
            foreach (Container c in loadedContainerList)
            {
                lboxLoadedContainers.Items.Add(c.ContainerInformation());
            }
        }

        private void btnAddShip_Click(object sender, EventArgs e)
        {
            int widthShip = Convert.ToInt32(nUDWidthOfShip.Value);
            int lengthShip = Convert.ToInt32(nUDLengthShip.Value);
            Ship ship = new Ship(widthShip, lengthShip);
            _shipList.Add(ship);
            lboxShip.Items.Add(ship);
        }

        private void btnAddContainer_Click(object sender, EventArgs e)
        {
            int containerWeight = Convert.ToInt32(nUDContainerWeight.Value);
            bool add = true;
            Container container = new Container(containerWeight, ContainerType.Normal);

            if (cBoxCooled.Checked && cBoxValueable.Checked)
            {
                MessageBox.Show("Only one type of container can be selected.");
                add = false;
            }
            else if (cBoxValueable.Checked)
            {
                container.Type = ContainerType.Valuable;
            }
            else if (cBoxCooled.Checked)
            {
                container.Type = ContainerType.Cooled;
            }

            if (!add) return;
            _containerList.Add(container);
            lboxContainers.Items.Add(container.ToString());
        }

        private void btnCalculateOptimalLayout_Click(object sender, EventArgs e)
        {
            ContainerDistribution containerDistribution = new ContainerDistribution(_shipList[0], _containerList);
            if (containerDistribution.PlaceAllContainers() == true)
            {
                MessageBox.Show("All containers placed on ship");
                lblLink.Text = "Link: " + _shipList[0].GetUrl();
                ShowLoadedContainers(containerDistribution.GetLoadedContainers());
            }
            else
            {
                MessageBox.Show("Not all containers fit on current ship.");
            }
        }
    }
}
