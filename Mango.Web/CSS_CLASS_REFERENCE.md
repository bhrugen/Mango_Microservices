# Mango.Web CSS Class Reference

## 🎨 Design Philosophy
This CSS system **enhances** Bootstrap 5.3.8 without breaking its defaults. All custom styles are **opt-in** through specific class names.

---

## 📋 Custom CSS Classes

### Gradients
```css
.bg-gradient              /* Primary purple gradient background */
.text-gradient-gold       /* Gold text gradient (for brand) */
```

### Cards
```css
.card-hover              /* Adds lift effect on hover */
.product-card            /* Specific styling for product cards */
.card-header.bg-gradient /* Gradient header for cards */
.card-header-dark        /* Dark header alternative */
```

### Buttons (Gradient Versions)
```css
.btn-gradient-primary    /* Purple gradient button */
.btn-gradient-success    /* Green gradient button */
.btn-gradient-warning    /* Pink gradient button */
```
**Note:** Standard Bootstrap buttons (`.btn-primary`, `.btn-success`, etc.) work normally!

### Badges
```css
.badge-gradient-warning  /* Pink gradient badge */
```
**Note:** Standard Bootstrap badges work normally!

### Tables
```css
.table thead.table-gradient  /* Gradient table header (opt-in) */
```

### Navbar
```css
.navbar-dark .nav-link   /* Enhanced hover effects for dark navbar */
.dropdown-menu-modern    /* Modern dropdown styling */
```

### Animations
```css
.fade-in-up             /* Fade in with upward motion */
```

### Utilities
```css
.shadow-soft            /* Subtle shadow */
.shadow-hover           /* Enhanced shadow on hover */
.hero-section          /* Hero banner styling */
.cart-item             /* Cart row styling */
.price-tag             /* Price display styling */
```

---

## 🚀 Usage Examples

### Product Card
```html
<div class="card product-card card-hover h-100">
	<img src="..." class="card-img-top" alt="...">
	<div class="card-body">
		<h5 class="card-title">Product Name</h5>
		<p class="price-tag">$19.99</p>
	</div>
</div>
```

### Modern Dropdown
```html
<div class="dropdown-menu dropdown-menu-modern">
	<a class="dropdown-item" href="#"><i class="bi bi-person"></i> Profile</a>
	<a class="dropdown-item" href="#"><i class="bi bi-gear"></i> Settings</a>
</div>
```

### Gradient Button
```html
<button class="btn btn-gradient-primary">Shop Now</button>
```
**Or use standard Bootstrap:**
```html
<button class="btn btn-primary">Shop Now</button>
```

### Card with Gradient Header
```html
<div class="card">
	<div class="card-header bg-gradient text-white">
		<h5 class="mb-0">Order Summary</h5>
	</div>
	<div class="card-body">
		<!-- Content -->
	</div>
</div>
```

---

## ⚠️ Important Notes

1. **Bootstrap Classes Work Normally**
   - `.btn-primary`, `.btn-success`, `.bg-warning`, etc. are NOT overridden
   - Use gradient versions only when you want the custom gradient effect

2. **Hover Effects Are Opt-In**
   - Add `.card-hover` to cards that should lift on hover
   - Not all cards need hover effects (e.g., form containers)

3. **Product-Specific Classes**
   - Use `.product-card` for product listings
   - Use `.cart-item` for shopping cart rows
   - Use `.price-tag` for price displays

4. **Responsive Design**
   - All Bootstrap 5.3.8 responsive utilities work normally
   - Custom styles include mobile breakpoints

---

## 🎯 Migration from Old site.css

### Old Aggressive Overrides (Removed)
```css
/* ❌ These are REMOVED - they broke Bootstrap */
.btn-success { background: gradient... }  /* Broke all success buttons */
.card:hover { transform... }              /* Made ALL cards lift */
.card-title { background: gradient... }   /* Forced gradient on all titles */
.bg-warning { background: gradient... }   /* Broke warning badges */
```

### New Opt-In Approach
```css
/* ✅ These are opt-in - Bootstrap works normally */
.btn-gradient-success { background: gradient... }  /* Use when you want it */
.card-hover { transform... }                       /* Add to specific cards */
.card-header.bg-gradient { background... }         /* Specific header style */
.badge-gradient-warning { background... }          /* Custom badge variant */
```

---

## 📚 Teaching Points for Microservices Course

### CSS Architecture Lessons
1. **Separation of Concerns**: Shared UI library vs. service-specific styles
2. **Progressive Enhancement**: Build on framework, don't override
3. **Naming Conventions**: BEM-like, descriptive class names
4. **Specificity Management**: Avoid `!important` where possible
5. **Maintainability**: Opt-in classes are easier to debug

### Front-End in Microservices
- Shared design system across micro-frontends
- CDN vs. bundled assets for distributed teams
- Component libraries that work with any framework
- Design tokens and CSS variables
- Theming strategies

---

## 🔧 Customization

All colors are defined as CSS variables in `:root`:
```css
:root {
	--primary-gradient: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
	--warning-gradient: linear-gradient(135deg, #f093fb 0%, #f5576c 100%);
	--success-gradient: linear-gradient(135deg, #4facfe 0%, #00f2fe 100%);
	--dark-bg: #1a1a2e;
	--card-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
	--hover-shadow: 0 15px 40px rgba(0, 0, 0, 0.2);
}
```

Update these to change your theme globally!
