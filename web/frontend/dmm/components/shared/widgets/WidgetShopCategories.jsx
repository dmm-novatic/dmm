import React, { useEffect, useState } from 'react';
import Link from 'next/link';
import ProductCategory from '~/repositories/ProductCategory';

const WidgetShopCategories = ({ cateId = null }) => {
    const [categories, setCategories] = useState(null);
    const [loading, setLoading] = useState(false);
    async function getCategories() {
        setLoading(true);
        const responseData = await ProductCategory.getCategoryFull();
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
                    className={(cateId && item.id + '' === cateId) ? 'active':''}>
                    <Link href={`/shop?category=${item.id}`}>{item.name}</Link>
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
            <h4 className="widget-title">Categories</h4>
            {categoriesView}
        </aside>
    );
};

export default WidgetShopCategories;
