<%@ page language="C#" masterpagefile="~/mstClientPage.master" autoeventwireup="true" inherits="PhotoGallery, App_Web_ubdslfxn" title="Photo Gallery | Nagar Bandhara Community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" href="css/style-jcarousel.css" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <div class="middle-cnt">
        <div class="abt_section">
            <h1>
                Photo Gallery</h1>
            <div id="content">
                <div class="theme-clear-slider">
                    <div class="arrow-left">
                        <a href="#scroll" class="carousel_0_next"></a>
                    </div>
                    <div class="arrow-right">
                        <a href="#scroll" class="carousel_0_prev"></a>
                    </div>
                    <div class="jcarousel-skin-clear-slider">
                        <div style="overflow: hidden; position: relative;" class="jcarousel-clip jcarousel-clip-horizontal">
                            <ul id="carousel_0">
                                <asp:Repeater ID="rptImageThumbnail" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img onmouseover="ctl00_Contentplaceholder1_preview.src=img<%# Eval("PhotoCode") %>.src" id='img<%# Eval("PhotoCode") %>'
                                                src='PhotoGallery/<%# Eval("FileName") %>' alt="Image Not Loaded" />
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div>
            <img id="preview" runat="server" src="" alt="No Image Loaded">
        </div>
    </div>
    <div class="f-main">
        <h4>
            Album Name</h4>
        <ul>
            <asp:Repeater ID="rptPhotoAlbum" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:LinkButton ID="lnkAlbum" ToolTip='<%# Eval("AlbumName") %>' CommandArgument='<%# Eval("AlbumCode") %>'
                            runat="server" OnClick="lnkAlbum_Click"><%# ProcessAlbumName(DataBinder.Eval(Container.DataItem,"AlbumName")) %></asp:LinkButton></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomContent" runat="Server">

    <script type="text/javascript">
			jQuery(document).ready(function() {
				jQuery('#carousel_0').jcarousel({
					scroll: 1,
					wrap: 'both',
					auto: 0,
					vertical: false				});
					jQuery('.carousel_0_next').click(function() {
					jQuery('#carousel_0').jcarousel('prev');
					jQuery('#carousel_0').data('jcarousel').startAuto(0);
					return false;
				});
				jQuery('#carousel_0-paginate a').bind('click', function() {
					jQuery('#carousel_0').data('jcarousel').scroll(jQuery.jcarousel.intval(jQuery(this).text()));
					jQuery('#carousel_0').data('jcarousel').startAuto(0);
					return false;
				});
				jQuery('.carousel_0_prev').click(function() {
					jQuery('#carousel_0').jcarousel('next');
					jQuery('#carousel_0').data('jcarousel').startAuto(0);
					return false;
				});
			});
    </script>

    <script type="text/javascript" src="js/jcarousel.js"></script>

</asp:Content>
