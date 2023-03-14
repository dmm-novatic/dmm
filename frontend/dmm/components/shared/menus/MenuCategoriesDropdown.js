import React, { useEffect, useState } from 'react';
import Menu from '~/components/elements/menu/Menu';
import ShopRepository from '~/repositories/ShopRepository';

const MenuCategoriesDropdown = () => {
    const [listShop, setListShop] = useState();
    const getListShop = async () => {
        const data = await ShopRepository.getTop5Shop();
        if (data) {
            const listMenuData = [];
            data.map((item) => {
                const itemMenu = {};
                if (item.icon) {
                    itemMenu.icon = item.icon;
                } else {
                    itemMenu.icon = 'icon-star';
                }
                itemMenu.text = item.name;
                itemMenu.url = `/home/auto-part?shopId=${item.id}`;
                listMenuData.push(itemMenu);
            });
            setListShop(listMenuData);
        }
    };
    useEffect(() => {
        if (!listShop) {
            getListShop();
        }
    });
    return (
        <div className="menu--product-categories">
            <div className="menu__toggle">
                <i className="icon-menu"></i>
                <span>Shop</span>
            </div>
            <div className="menu__content">
                <Menu
                    source={listShop && listShop}
                    className="menu--dropdown"
                />
            </div>
        </div>
    );
};

export default MenuCategoriesDropdown;
