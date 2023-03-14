import React from 'react';
import Link from 'next/link';

const ModuleProductDetailDescription = ({ product }) => (
    <div className="ps-product__desc">
        <p>
            Sold By:
            <strong> {product.shopName}</strong>
        </p>
        <ul className="ps-list--dot">
            <li>Remaining products: {product.quantity} </li>
            <li>Unrestrained and portable active stereo speaker</li>
            <li> Free from the confines of wires and chords</li>
            <li> 20 hours of portable capabilities</li>
        </ul>
    </div>
);

export default ModuleProductDetailDescription;
