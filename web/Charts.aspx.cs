using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class Charts : JamPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ctrLyrics.FillForm();
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        ctrLyrics.Visible = false;
        ctrMusic.Visible = true;
        ctrVideo.Visible = false;

        ctrMusic.FillForm();

        SetPageTitleDescr(new string[] { 
                                "Charts", 
                                "Чарты" },
            new string[] { 
                    "Music and lyrics on the charts.", 
                    "Чарты музыки и стихов, составленные на основе голосования пользователей music-head."});

    }
    protected void lbtnLyrics_Click(object sender, EventArgs e)
    {
        ctrLyrics.Visible = true;
        ctrMusic.Visible = false;
        ctrVideo.Visible = false;

        ctrLyrics.FillForm();
    }
    protected void lbtnVideo_Click(object sender, EventArgs e)
    {
        ctrLyrics.Visible = false;
        ctrMusic.Visible = false;
        ctrVideo.Visible = true;

        ctrVideo.FillForm();
    }
}
