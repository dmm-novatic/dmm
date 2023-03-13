import React, { Component, useEffect, useState } from 'react';
import Link from 'next/link';
import { notification } from 'antd';
import Menu from '../../elements/menu/Menu';
import CurrencyDropdown from '../headers/modules/CurrencyDropdown';
import LanguageSwicher from '../headers/modules/LanguageSwicher';
import MenuCategoriesDropdown from '~/components/shared/menus/MenuCategoriesDropdown';
import ShopRepository from '~/repositories/ShopRepository';
import ProductCategory from '~/repositories/ProductCategory';
import ProductRepository from '~/repositories/ProductRepository';

class NavigationDefault extends Component {
    constructor(props) {
        super(props);
        this.state = {
            menuCategory: [],
            menuBrand: [],
        };
    }

    handleFeatureWillUpdate(e) {
        e.preventDefault();
        notification.open({
            message: 'Opp! Something went wrong.',
            description: 'This feature has been updated later!',
            duration: 500,
        });
    }
    async componentDidMount() {
        if (this.state.menuCategory.length === 0) {
            const result = await ProductCategory.getCategoryFull();
            if (result) {
                const dataMenu = [];
                let data = {};
                data.text = 'Category';
                data.url = '/';
                data.subClass = 'sub-menu';
                let listShop = [];
                result.map((item) => {
                    let items = {};
                    items.text = item.name;
                    items.url = '/shop/?category=' + item.id;
                    listShop.push(items);
                });
                data.subMenu = listShop;
                dataMenu.push(data);
                this.setState({ menuCategory: dataMenu });
            }
        }
        if (this.state.menuBrand.length === 0) {
            const result = await ProductRepository.getAllBrand();
            if (result) {
                const dataMenu = [];
                let data = {};
                data.text = 'Brand';
                data.url = '/';
                data.subClass = 'sub-menu';
                let listShop = [];
                result.map((item) => {
                    let items = {};
                    items.text = item.name;
                    items.url = '/shop/?brand=' + item.id;
                    listShop.push(items);
                });
                data.subMenu = listShop;
                dataMenu.push(data);
                this.setState({ menuBrand: dataMenu });
            }
        }
    }
    // Views
    render() {
        return (
            <nav className="navigation" style={{padding:this.props.isShop&&"15px"}}>
                <div className="ps-container">
                    <div className="navigation__left">
                        <MenuCategoriesDropdown />
                    </div>
                    <div className="navigation__right">
                        {this.props.isShop === false && (
                            <div
                                style={{
                                    display: 'flex',
                                    justifyContent: 'space-between',
                                    width: '15%',
                                }}>
                                {this.state.menuCategory.length !== 0 && (
                                    <Menu
                                        source={
                                            this.state.menuCategory.length !==
                                                0 && this.state.menuCategory
                                        }
                                        className="menu"
                                    />
                                )}
                                {this.state.menuBrand.length !== 0 && (
                                    <Menu
                                        source={
                                            this.state.menuBrand.length !== 0 &&
                                            this.state.menuBrand
                                        }
                                        className="menu"
                                    />
                                )}
                            </div>
                        )}
                        <ul className="navigation__extra">
                            <li>
                                <Link href="/vendor/become-a-vendor">
                                    <a>Sell on DMM</a>
                                </Link>
                            </li>
                            <li>
                                <Link href="/account/order-tracking">
                                    <a>Tract your order</a>
                                </Link>
                            </li>
                            <li>
                                <CurrencyDropdown />
                            </li>
                            <li>
                                <LanguageSwicher />
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}

export default NavigationDefault;
