import React, { useEffect, useState } from 'react';
import ProductRepository from '~/repositories/ProductRepository';
import Link from 'next/link';

const WidgetShopBrands = ({ brandId = null }) => {
    const [categories, setCategories] = useState(null);
    const [loading, setLoading] = useState(false);
    async function getCategories() {
        setLoading(true);
        const responseData = await ProductRepository.getAllBrand();
        if (responseData) {
            setCategories(responseData);
            setTimeout(
                function () {
                    setLoading(false);
                }.bind(this),
                250
            );
        }
    }

    useEffect(() => {
        getCategories();
    }, []);

    // Views
    let categoriesView;
    if (!loading) {
        if (categories && categories.length > 0) {
            const items = categories.map((item) => (
                <li
                    key={item.id}
                    className={
                        brandId && item.id + '' === brandId ? 'active' : ''
                    }>
                    <Link href={`/shop?brand=${item.id}`}>{item.name}</Link>
                </li>
            ));
            categoriesView = <ul className="ps-list--categories">{items}</ul>;
        } else {
        }
    } else {
        categoriesView = <p>Loading...</p>;
    }

    return (
        <aside className="widget widget_shop">
            <h4 className="widget-title">Brands</h4>
            {categoriesView}
        </aside>
    );
};

export default WidgetShopBrands;
