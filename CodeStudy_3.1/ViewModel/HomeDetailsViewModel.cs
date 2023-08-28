using CodeStudy_3._1.Model;

namespace CodeStudy_3._1.ViewModel
{
    public class HomeDetailsViewModel
    {
        //装载Student类的数据和PageTitles，然后从Controller传递数据到View
        public Student student { get; set; }
        public string PageTiles { get; set; }
    }
}
