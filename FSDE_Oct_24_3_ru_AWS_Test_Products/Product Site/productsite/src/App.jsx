import {Link, Navigate, Routes, Route} from 'react-router-dom'
import ProductDetails from "./pages/ProductDetails.jsx";
import ProductList from "./pages/ProductList.jsx";
import ProjectCreate from "./pages/ProjectCreate.jsx";
import ProductEdit from "./pages/ProductEdit.jsx";
export default function App(){
  return (
      <div className="container py-4">
        <header className="d-flex justify-content-between align-items-center mb-4">
          <h1 className="h3 m-0">MoguDa SHOP</h1>
          <Link
              to="/products"
              className="btn btn-outline-primary">
            Products
          </Link>
        </header>
        <Routes>
          <Route path="/" element={<Navigate to="/products" replace/>} />
          <Route path="/products" element={<ProductList />} />
          <Route path="/products/create" element={<ProjectCreate />} />
          <Route path="/products/edit/:id" element={<ProductEdit />} />
          <Route path="/products/:id" element={<ProductDetails />} />
        </Routes>
      </div>
  )
}