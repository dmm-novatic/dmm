import React, { useEffect, useState } from 'react';
import Link from 'next/link';
import MenuDropdown from './MenuDropdown';
import MegaMenu from '~/components/elements/menu/MegaMenu';
import ShopRepository from '~/repositories/ShopRepository';
const Menu = ({ source, className }) => {
    // Views
    let menuView;
    if (source) {
        menuView = source.map((item) => {
            if (item.subMenu) {
                return <MenuDropdown source={item} key={item.text} />;
            }
            //  else if (item.megaContent) {
            //     return <MegaMenu source={item} key={item.text} />;
            // } else {
            //     return (
            //         <li key={item.text}>
            //             <Link href={item.url}>
            //                 <a>
            //                     {item.icon && <i className={item.icon}></i>}
            //                     {item.text}
            //                 </a>
            //             </Link>
            //         </li>
            //     );
            // }
        });
    } else {
        menuView = (
            <li>
                <a href="#" onClick={(e) => e.preventDefault()}>
                    No menu item.
                </a>
            </li>
        );
    }
    const menuViews = () => {
        if (source&&source.length !== 0) {
            return (
                <>
                    {source.map((item, index) => {
                        return <MenuDropdown source={item} key={index} />;
                    })}
                </>
            );
        } else {
            return (
                <li>
                    <a href="#" onClick={(e) => e.preventDefault()}>
                        No menu item.
                    </a>
                </li>
            );
        }
    };
    return <ul className={className}>{source&&source.length > 0 && menuViews()}</ul>;
};

export default Menu;
