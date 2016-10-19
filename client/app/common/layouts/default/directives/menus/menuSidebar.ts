import {Component, AfterViewInit} from "angular2/core";
import {RouterLink, RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from "angular2/router";
import { MenuItem as MenuItemDir} from "../../directives/all";
import {MenuItem} from "../../../../models/layout";
import configHelper from "../../../../helpers/configHelper";
declare var $: any;
@Component({
    selector: "menu-sidebar",
    templateUrl: "app/common/layouts/default/directives/menus/menuSidebar.html",
    directives: [ROUTER_DIRECTIVES, RouterLink, MenuItemDir]
})
export class MenuSidebar implements AfterViewInit {
    constructor() {
        this.menuItems = configHelper.getModuleMenuItems();
    }
    public menuItems: any = [];
    public title: string = "";
    ngAfterViewInit() {
        this.initializedSidebar();
    }
    /* tslint:disable */
    private initializedSidebar(): any {
        var CURRENT_URL = window.location.href.split('?')[0],
        $BODY = $('body'),
        $MENU_TOGGLE = $('#menu_toggle'),
        $SIDEBAR_MENU = $('#sidebar-menu'),
        $SIDEBAR_FOOTER = $('.sidebar-footer'),
        $LEFT_COL = $('.left_col'),
        $RIGHT_COL = $('.right_col'),
        $NAV_MENU = $('.nav_menu'),
        $FOOTER = $('footer');
        
        $(document).ready(function() {
            
            var setContentHeight = function () {
                $RIGHT_COL.css('min-height', $(window).height());
                var bodyHeight = $BODY.height(),
                    leftColHeight = $LEFT_COL.eq(1).height() + $SIDEBAR_FOOTER.height(),
                    contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;
                contentHeight -= $NAV_MENU.height() + $FOOTER.height();
                $RIGHT_COL.css('min-height', contentHeight);
            };

            $SIDEBAR_MENU.find('a').on('click', function(ev: any) {
                var $li = $(this).parent();
                if ($li.is('.active')) {
                    $li.removeClass('active');
                    $('ul:first', $li).slideUp(function() {
                        setContentHeight();
                    });
                } else {
                    if (!$li.parent().is('.child_menu')) {
                        $SIDEBAR_MENU.find('li').removeClass('active');
                        $SIDEBAR_MENU.find('li ul').slideUp();
                    }
                    $li.addClass('active');
                    $('ul:first', $li).slideDown(function() {
                        setContentHeight();
                    });
                }
            });
            $MENU_TOGGLE.on('click', function() {
                if ($BODY.hasClass('nav-md')) {
                    $BODY.removeClass('nav-md').addClass('nav-sm');

                    if ($SIDEBAR_MENU.find('li').hasClass('active')) {
                        $SIDEBAR_MENU.find('li.active').addClass('active-sm').removeClass('active');
                    }
                } else {
                    $BODY.removeClass('nav-sm').addClass('nav-md');

                    if ($SIDEBAR_MENU.find('li').hasClass('active-sm')) {
                        $SIDEBAR_MENU.find('li.active-sm').addClass('active').removeClass('active-sm');
                    }
                }

                setContentHeight();
            });
            $SIDEBAR_MENU.find('a[href="' + CURRENT_URL + '"]').parent('li').addClass('current-page');
            $SIDEBAR_MENU.find('a').filter(function () {
                return this.href == CURRENT_URL;
            }).parent('li').addClass('current-page').parents('ul').slideDown(function() {
                setContentHeight();
            }).parent().addClass('active');
            $(window).smartresize(function(){  
                setContentHeight();
            });
            if ($.fn.mCustomScrollbar) {
                $('.menu_fixed').mCustomScrollbar({
                    autoHideScrollbar: true,
                    theme: 'minimal',
                    mouseWheel:{ preventDefault: true }
                });
            }
            setContentHeight();
        });
    }
    /* tslint:enable */
}