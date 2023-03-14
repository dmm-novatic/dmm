import React, { useEffect, useRef, useState } from 'react';
import Link from 'next/link';
import { useRouter } from 'next/router';
import { Spin } from 'antd';
import ProductRepository from '~/repositories/ProductRepository';
import ProductSearchResult from '~/components/elements/products/ProductSearchResult';
import ProductCategory from '~/repositories/ProductCategory';
import { notification } from 'antd';
const exampleCategories = [
    'All',
    'Babies & Moms',
    'Books & Office',
    'Cars & Motocycles',
    'Clothing & Apparel',
    ' Accessories',
    'Bags',
    'Kid’s Fashion',
    'Mens',
    'Shoes',
    'Sunglasses',
    'Womens',
    'Computers & Technologies',
    'Desktop PC',
    'Laptop',
    'Smartphones',
    'Consumer Electrics',
    'Air Conditioners',
    'Accessories',
    'Type Hanging Cell',
    'Audios & Theaters',
    'Headphone',
    'Home Theater System',
    'Speakers',
    'Car Electronics',
    'Audio & Video',
    'Car Security',
    'Radar Detector',
    'Vehicle GPS',
    'Office Electronics',
    'Printers',
    'Projectors',
    'Scanners',
    'Store & Business',
    'Refrigerators',
    'TV Televisions',
    '4K Ultra HD TVs',
    'LED TVs',
    'OLED TVs',
    'Washing Machines',
    'Type Drying Clothes',
    'Type Horizontal',
    'Type Vertical',
    'Garden & Kitchen',
    'Cookware',
    'Decoration',
    'Furniture',
    'Garden Tools',
    'Home Improvement',
    'Powers And Hand Tools',
    'Utensil & Gadget',
    'Health & Beauty',
    'Equipments',
    'Hair Care',
    'Perfumer',
    'Wine Cabinets',
];

function useDebounce(value, delay) {
    const [debouncedValue, setDebouncedValue] = useState(value);
    useEffect(() => {
        // Update debounced value after delay
        const handler = setTimeout(() => {
            setDebouncedValue(value);
        }, delay);

        return () => {
            clearTimeout(handler);
        };
    }, [value, delay]);

    return debouncedValue;
}

const SearchHeader = () => {
    const Router = useRouter();
    const [shopId, setShopId] = useState('0');
    useEffect(() => {
        if (Router.query.shopId) {
            setShopId(Router.query.shopId);
        }
    }, [Router.query.shopId]);

    const inputEl = useRef(null);
    const [isSearch, setIsSearch] = useState(false);
    const [keyword, setKeyword] = useState('');
    const [cateId, setCateId] = useState('0');
    const [resultItems, setResultItems] = useState(null);
    const [loading, setLoading] = useState(false);
    const debouncedSearchTerm = useDebounce(keyword, 300);
    const [categoryList, setCategoryList] = useState();
    function handleClearKeyword() {
        setKeyword('');
        setIsSearch(false);
        setLoading(false);
    }

    function handleSubmit(e) {
        if (keyword !== null || keyword !== '' || keyword.trim() !== '') {
            e.preventDefault();
            let str = keyword.replaceAll('\\s\\s+', ' ').trim();
            Router.push(
                `/search?keyword=${str}&cateID=${cateId}&shopId=${shopId}`
            );
        }
    }
    useEffect(() => {
        let str = keyword.replaceAll('\\s\\s+', ' ').trim();
        if (!categoryList) {
            getCategory();
        }
        if (debouncedSearchTerm) {
            setLoading(true);
            if (
                keyword &&
                keyword.trim() !== '' &&
                keyword !== null &&
                keyword !== ''
            ) {
                const queries = {
                    textSearch: str,
                    cateID: cateId,
                    pageSize: 10,
                    pageIndex: 1,
                    shopId: shopId,
                };

                const products = ProductRepository.getSearchRecords(queries);
                if (products) {
                    products.then((result) => {
                        setLoading(false);
                        setResultItems(result);
                        setIsSearch(true);
                    });
                }
            } else {
                setIsSearch(false);
                setKeyword('');
            }
            if (loading) {
                setIsSearch(false);
            }
        } else {
            setLoading(false);
            setIsSearch(false);
        }
    }, [debouncedSearchTerm]);

    // Views
    let productItemsView,
        clearTextView,
        selectOptionView,
        loadingView,
        loadMoreView;
    if (!loading) {
        if (resultItems && resultItems.length > 0) {
            if (resultItems.length > 5) {
                loadMoreView = (
                    <div className="ps-panel__footer text-center">
                        <div onClick={(e) => handleSubmit(e)}>
                            <a>See all results</a>
                        </div>
                    </div>
                );
            }
            productItemsView = resultItems.map((product) => (
                <ProductSearchResult product={product} key={product.id} />
            ));
        } else {
            productItemsView = <p>No product found.</p>;
        }
        if (keyword !== '') {
            clearTextView = (
                <span className="ps-form__action" onClick={handleClearKeyword}>
                    <i className="icon icon-cross2"></i>
                </span>
            );
        }
    } else {
        loadingView = (
            <span className="ps-form__action">
                <Spin size="small" />
            </span>
        );
    }
    const getCategory = async () => {
        const datas = [{ id: 0, name: 'All' }];
        const data = await ProductCategory.getCategoryFull();
        if (data) {
            data.map((item) => {
                datas.push(item);
            });
        }
        if (datas) {
            setCategoryList(datas);
        }
    };
    const handleChange = (e) => {
        setCateId(e.target.value);
    };
    return (
        <form
            className="ps-form--quick-search"
            method="get"
            action="/"
            onSubmit={handleSubmit}>
            <div className="ps-form__categories">
                <select
                    className="form-control"
                    style={{ cursor: 'pointer' }}
                    onChange={handleChange}>
                    {categoryList &&
                        categoryList.map((item) => {
                            return (
                                <option value={item.id} key={item.id}>
                                    {item.name}
                                </option>
                            );
                        })}
                </select>
            </div>
            <div className="ps-form__input">
                <input
                    ref={inputEl}
                    className="form-control"
                    type="text"
                    value={keyword}
                    placeholder="I'm shopping for..."
                    onChange={(e) => setKeyword(e.target.value)}
                    required
                />
                {clearTextView}
                {loadingView}
            </div>
            <button onClick={handleSubmit}>Search</button>
            <div
                className={`ps-panel--search-result${
                    isSearch ? ' active ' : ''
                }`}>
                <div className="ps-panel__content">{productItemsView}</div>
                {loadMoreView}
            </div>
        </form>
    );
};

export default SearchHeader;
