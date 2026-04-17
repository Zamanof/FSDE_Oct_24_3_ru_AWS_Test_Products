function ProductForm({
                         form,
                         imageFile,
                         onChange,
                         onImageChange,
                         onSubmit,
                         loading,
                         submitText,
                         error
                     }) {
    return (
        <form onSubmit={onSubmit} className="card shadow-sm p-4">
            <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                    type="text"
                    name="name"
                    className="form-control"
                    value={form.name}
                    onChange={onChange}
                    required
                    maxLength={100}
                />
            </div>

            <div className="mb-3">
                <label className="form-label">Description</label>
                <textarea
                    name="description"
                    className="form-control"
                    rows="4"
                    value={form.description}
                    onChange={onChange}
                    required
                    maxLength={1000}
                />
            </div>

            <div className="row">
                <div className="col-md-6 mb-3">
                    <label className="form-label">Price</label>
                    <input
                        type="number"
                        name="price"
                        className="form-control"
                        value={form.price}
                        onChange={onChange}
                        required
                        min="0.01"
                        step="0.01"
                    />
                </div>
                <div className="col-md-6 mb-3">
                    <label className="form-label">Category</label>
                    <input
                        type="text"
                        name="category"
                        className="form-control"
                        value={form.category}
                        onChange={onChange}
                        required
                        maxLength={100}
                    />
                </div>
            </div>

            <div className="mb-3">
                <label className="form-label">Image</label>
                <input type="file" className="form-control" accept="image/*" onChange={onImageChange} />
                {imageFile ? <small className="text-muted">Selected: {imageFile.name}</small> : null}
            </div>

            {error ? <div className="alert alert-danger">{error}</div> : null}

            <button type="submit" className="btn btn-primary" disabled={loading}>
                {loading ? "Saving..." : submitText}
            </button>
        </form>
    );
}

export default ProductForm;