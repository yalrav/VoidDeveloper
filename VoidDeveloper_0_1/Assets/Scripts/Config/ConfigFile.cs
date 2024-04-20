using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Config
{
	public class ConfigFile
	{
        public const string NameConfig = "cfg.txt" ;
        public int Read()
        {
            if (File.Exists(NameConfig)){ 
                using var sr = new StreamReader(NameConfig);

                return int.Parse(sr.ReadLine());
            }
            else
            {
                Write(1);
                return 1;
            }
        }

        public void Write(int val)
        {
            using var sw = new StreamWriter(NameConfig);

            sw.WriteLine(val);
        }

        
    }
}