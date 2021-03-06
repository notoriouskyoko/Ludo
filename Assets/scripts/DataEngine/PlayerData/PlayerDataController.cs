﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using game.player;
using UnityEngine;

public class PlayerDataController
{
	public void SavePlayerData()
	{
		string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ludo\data\player.json";


        JObject jobject = new JObject();

		jobject.Add(Player.getPlayer().getName());
		jobject.Add(Player.getPlayer().getTeam());

        try
		{

			if (File.Exists(path))
			{
				File.Delete(path);
			}
			using (FileStream fs = File.Create(path))
			{
			  File.AppendAllText(path, jobject.ToString());
			}

			using (StreamReader sr = File.OpenText(path))
			{
				string s = "";
				while ((s = sr.ReadLine()) != null)
				{
					Debug.Log(s);
				}
			}
		}

		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}
}

