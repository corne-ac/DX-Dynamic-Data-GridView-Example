using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }

        // Constructor to initialize Id
        public Component(int id)
        {
            this.Id = id;
        }
    }

    public class ComponentData
    {
        // Method to populate components
        void PopulateComponents()
        {
            components = new ObservableCollection<Component>
            {
                new Component(1)
                {
                    Name = "UltraWide Monitor",
                    Description = "34-inch ultrawide monitor with 1440p resolution and 100Hz refresh rate.",
                    Type = "Monitor",
                    IsActive = true,
                },
                new Component(2)
                {
                    Name = "Graphics Tablet",
                    Description = "Professional graphics tablet with pressure-sensitive pen for digital drawing.",
                    Type = "Peripheral",
                    IsActive = false,
                },
                new Component(3)
                {
                    Name = "Laptop Cooling Pad",
                    Description = "Portable laptop cooling pad with adjustable fan speed.",
                    Type = "Accessory",
                    IsActive = false,
                },
                new Component(4)
                {
                    Name = "Smartphone Gimbal",
                    Description = "3-axis smartphone gimbal stabilizer for smooth video recording.",
                    Type = "Accessory",
                    IsActive = true,
                },
                new Component(5)
                {
                    Name = "Wireless Keyboard and Mouse Combo",
                    Description = "Compact wireless keyboard and mouse combo with 2.4GHz connectivity.",
                    Type = "Peripheral",
                    IsActive = true,
                },
                new Component(6)
                {
                    Name = "External Hard Drive",
                    Description = "2TB external hard drive with USB 3.0 connectivity for data storage.",
                    Type = "Storage",
                    IsActive = true,
                },
                new Component(7)
                {
                    Name = "Wireless Router",
                    Description = "Dual-band wireless router with Gigabit Ethernet ports for high-speed internet access.",
                    Type = "Networking",
                    IsActive = true,
                },
                new Component(8)
                {
                    Name = "Bluetooth Speaker",
                    Description = "Portable Bluetooth speaker with built-in microphone for hands-free calling.",
                    Type = "Audio",
                    IsActive = false,
                },
                new Component(9)
                {
                    Name = "External Webcam",
                    Description = "1080p external webcam with privacy cover and auto-focus feature.",
                    Type = "Peripheral",
                    IsActive = true,
                },
                new Component(10)
                {
                    Name = "USB-C Docking Station",
                    Description = "USB-C docking station with multiple ports for connecting peripherals to a laptop.",
                    Type = "Accessory",
                    IsActive = false,
                }
            };

        }

        public ObservableCollection<Component> components { get; private set; }

        public ComponentData()
        {
            PopulateComponents();
        }
    }
}
