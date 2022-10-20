using BarotraumaSaveEditorGui.Utils;

namespace BarotraumaSaveEditorGui.Services.PageService
{
	internal interface IPageService
	{
		void Show(ViewModelBase viewModel);
		void Close();
	}
}
