using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ACE.RSGlobal;

public class ElipseFormAngles
{
	private int int_0;

	private int int_1;

	private GraphicsPath graphicsPath_0;

	private Form form_0;

	public ElipseFormAngles(Form form)
	{
		form_0 = form;
		graphicsPath_0 = new GraphicsPath();
		Rectangle rect = new Rectangle(0, 0, form.Width, form.Height);
		graphicsPath_0.AddRectangle(rect);
		CutLines(Class16.smethod_0(1649167074), 6, 5, 4, 3, 2, 1);
		CutLines(Class16.smethod_0(1649167088), 7, 6, 5, 4, 3, 2, 1);
		CutLines(Class16.smethod_0(1649167104), 6, 5, 4, 3, 2, 1);
		CutLines(Class16.smethod_0(1649167127), 7, 6, 5, 4, 3, 2, 1);
		form.Region = new System.Drawing.Region(graphicsPath_0);
		GC.KeepAlive(this);
	}

	public void CutLine(string Angle, int pix_count)
	{
		if (0 < pix_count)
		{
			int num = pix_count;
			do
			{
				Rectangle rect = new Rectangle(int_0, int_1, 1, 1);
				graphicsPath_0.AddRectangle(rect);
				if (Angle == Class16.smethod_0(1649167074))
				{
					int_0++;
				}
				if (Angle == Class16.smethod_0(1649167088))
				{
					int_0++;
				}
				if (Angle == Class16.smethod_0(1649167104))
				{
					int_0--;
				}
				if (Angle == Class16.smethod_0(1649167127))
				{
					int_0--;
				}
				num--;
			}
			while (num != 0);
		}
		if (Angle == Class16.smethod_0(1649167074))
		{
			int_0 = 0;
			int_1++;
		}
		if (Angle == Class16.smethod_0(1649167088))
		{
			int_0 = 0;
			int_1--;
		}
		if (Angle == Class16.smethod_0(1649167104))
		{
			int_0 = form_0.Width;
			int_1++;
		}
		if (Angle == Class16.smethod_0(1649167127))
		{
			int_0 = form_0.Width;
			int_1--;
		}
	}

	public void CutLines(string Angle, params int[] pix_counts)
	{
		if (Angle == Class16.smethod_0(1649167074))
		{
			int_0 = 0;
			int_1 = 0;
		}
		if (Angle == Class16.smethod_0(1649167088))
		{
			int_0 = 0;
			int_1 = form_0.Height;
		}
		if (Angle == Class16.smethod_0(1649167104))
		{
			int_0 = form_0.Width;
			int_1 = 0;
		}
		if (Angle == Class16.smethod_0(1649167127))
		{
			int_0 = form_0.Width;
			int_1 = form_0.Height;
		}
		int num = 0;
		if (0 < (nint)pix_counts.LongLength)
		{
			do
			{
				CutLine(Angle, pix_counts[num]);
				num++;
			}
			while (num < (nint)pix_counts.LongLength);
		}
	}
}
