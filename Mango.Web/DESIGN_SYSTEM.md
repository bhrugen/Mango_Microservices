# Mango Marketplace - Professional Design System

## 🎨 Design Philosophy

A modern, professional design system built on Bootstrap 5.3.8 with:
- **Clean aesthetics** - Subtle shadows, generous spacing, refined typography
- **Smooth interactions** - Meaningful transitions and micro-animations
- **Accessible** - WCAG compliant colors, focus states, screen reader support
- **Performance-first** - CSS variables, GPU-accelerated transforms
- **Mobile-optimized** - Responsive breakpoints, touch-friendly targets

---

## 🎯 Design Tokens

### Color System
```css
/* Brand Colors */
--primary: #6366f1        /* Indigo 500 */
--primary-dark: #4f46e5   /* Indigo 600 */
--primary-light: #818cf8  /* Indigo 400 */
--success: #10b981        /* Emerald 500 */
--warning: #f59e0b        /* Amber 500 */
--danger: #ef4444         /* Red 500 */

/* Neutrals */
--dark: #0f172a          /* Slate 900 */
--light: #f8fafc         /* Slate 50 */
--border: #e2e8f0        /* Slate 200 */
```

### Shadows (Layered Depth)
```css
--shadow-xs   /* Subtle hover state */
--shadow-sm   /* Default card elevation */
--shadow-md   /* Focused/active state */
--shadow-lg   /* Modals, dropdowns */
--shadow-xl   /* Popovers, elevated cards */
--shadow-2xl  /* Maximum elevation */
```

### Border Radius
```css
--radius-sm: 0.375rem   /* Small elements (badges, inputs) */
--radius-md: 0.5rem     /* Default (buttons, cards) */
--radius-lg: 0.75rem    /* Large cards */
--radius-xl: 1rem       /* Hero sections */
--radius-2xl: 1.5rem    /* Extra large containers */
--radius-full: 9999px   /* Pills, avatars */
```

### Transitions
```css
--transition-fast: 150ms  /* Hover states, button clicks */
--transition-base: 250ms  /* Default interactions */
--transition-slow: 350ms  /* Complex animations */
```

All use `cubic-bezier(0.4, 0, 0.2, 1)` easing (Material Design standard).

---

## 🧱 Component Library

### Navigation

#### Navbar
```html
<nav class="navbar navbar-expand-lg navbar-dark">
	<div class="container-fluid px-4">
		<a class="navbar-brand" href="#">
			<i class="bi bi-shop text-warning me-2"></i>
			<span class="text-gradient">Brand</span>
		</a>
		<!-- Nav items -->
	</div>
</nav>
```
**Features:**
- Glassmorphism effect (backdrop-filter blur)
- Animated underline on hover
- Gradient brand text
- Sticky positioning support

#### Dropdown
```html
<div class="dropdown-menu dropdown-menu-modern">
	<a class="dropdown-item" href="#">
		<i class="bi bi-person"></i> Profile
	</a>
	<div class="dropdown-divider"></div>
	<a class="dropdown-item" href="#">
		<i class="bi bi-box-arrow-right"></i> Logout
	</a>
</div>
```
**Features:**
- Fade-in animation
- Icon alignment
- Gradient hover effect
- Slide-in interaction

### Cards

#### Standard Card
```html
<div class="card">
	<div class="card-header">
		<h5 class="mb-0">Title</h5>
	</div>
	<div class="card-body">
		Content here
	</div>
</div>
```

#### Product Card
```html
<div class="card product-card card-hover h-100">
	<img src="..." class="card-img-top" alt="...">
	<div class="card-body">
		<h5 class="card-title">Product Name</h5>
		<p class="price-tag">$29.99</p>
		<a href="#" class="btn btn-primary">View Details</a>
	</div>
</div>
```
**Features:**
- Image zoom on hover
- Lift effect (translateY)
- Subtle shadow transitions
- Responsive image heights

#### Card with Gradient Header
```html
<div class="card">
	<div class="card-header bg-gradient text-white">
		<h5 class="mb-0"><i class="bi bi-star"></i> Premium Feature</h5>
	</div>
	<div class="card-body">
		<!-- Content -->
	</div>
</div>
```

### Buttons

#### Standard Buttons
```html
<!-- Bootstrap defaults work perfectly -->
<button class="btn btn-primary">Primary Action</button>
<button class="btn btn-success">Success</button>
<button class="btn btn-warning">Warning</button>
<button class="btn btn-outline-primary">Outline</button>
```
**Enhancements:**
- Ripple effect (::before pseudo-element)
- Lift on hover
- Scale on click (0.98)
- Improved shadows

#### Gradient Buttons (Special Cases)
```html
<button class="btn btn-gradient-primary">Premium Action</button>
<button class="btn btn-gradient-success">Complete</button>
<button class="btn btn-gradient-sunset">Featured</button>
```

#### Button Sizes
```html
<button class="btn btn-primary btn-sm">Small</button>
<button class="btn btn-primary">Default</button>
<button class="btn btn-primary btn-lg">Large</button>
```

### Forms

#### Text Input
```html
<div class="mb-3">
	<label class="form-label">Email Address</label>
	<input type="email" class="form-control" placeholder="you@example.com">
</div>
```
**Features:**
- 2px border
- Focus ring (4px rgba shadow)
- Hover state
- Validation states

#### Input Group
```html
<div class="input-group">
	<span class="input-group-text"><i class="bi bi-search"></i></span>
	<input type="text" class="form-control" placeholder="Search...">
</div>
```

#### Quantity Selector
```html
<div class="quantity-selector">
	<button type="button">-</button>
	<input type="number" value="1" readonly>
	<button type="button">+</button>
</div>
```
**Features:**
- Circular buttons
- Number input (centered)
- Scale animation on click
- Light background

### Badges & Tags

#### Standard Badge
```html
<span class="badge bg-primary">New</span>
<span class="badge bg-success">Active</span>
<span class="badge bg-warning text-dark">Featured</span>
```

#### Gradient Badges
```html
<span class="badge badge-gradient-primary">Premium</span>
<span class="badge badge-gradient-warning">Hot</span>
```

#### Category Badge (Pill)
```html
<span class="category-badge">
	<i class="bi bi-tag"></i> Electronics
</span>
```
**Features:**
- Pill shape (full border-radius)
- Hover gradient
- Icon support
- Border outline

#### Price Tag
```html
<div class="price-tag">$29.99</div>
<div class="price-tag-sm">$19.99</div>
```

### Tables

#### Standard Table
```html
<table class="table">
	<thead class="table-gradient">
		<tr>
			<th>Product</th>
			<th>Price</th>
			<th>Status</th>
		</tr>
	</thead>
	<tbody>
		<!-- Rows -->
	</tbody>
</table>
```
**Features:**
- Optional gradient header
- Row hover effect
- Rounded corners
- DataTables compatible

### Special Components

#### Hero Section
```html
<div class="hero-section text-white">
	<div class="container">
		<h1>Welcome to Mango Marketplace</h1>
		<p class="lead">Discover amazing products</p>
	</div>
</div>
```
**Features:**
- Gradient background
- Radial highlight overlay
- Responsive padding
- Large typography

#### Trust Badge
```html
<div class="trust-badge">
	<i class="bi bi-shield-check"></i>
	<div>
		<strong>Secure Checkout</strong>
		<div class="small text-muted">256-bit SSL Encryption</div>
	</div>
</div>
```

#### Cart Item
```html
<div class="cart-item">
	<div class="row align-items-center">
		<div class="col-2">
			<img src="..." class="img-fluid rounded">
		</div>
		<div class="col-6">
			<h6>Product Name</h6>
			<p class="text-muted small">Description</p>
		</div>
		<div class="col-2 text-center">
			<span class="badge bg-light text-dark">x 2</span>
		</div>
		<div class="col-2 text-end">
			<strong class="text-success">$49.98</strong>
		</div>
	</div>
</div>
```

---

## ✨ Animations

### Built-in Animations
```html
<div class="fade-in-up">Fades in from bottom</div>
<div class="slide-in-right">Slides in from left</div>
<div class="pulse">Pulses continuously</div>
```

### Staggered Animation (Auto)
```html
<!-- Children animate with delay -->
<div class="row">
	<div class="col fade-in-up">Item 1 (0ms delay)</div>
	<div class="col fade-in-up">Item 2 (100ms delay)</div>
	<div class="col fade-in-up">Item 3 (200ms delay)</div>
	<div class="col fade-in-up">Item 4 (300ms delay)</div>
</div>
```

### Skeleton Loader
```html
<div class="skeleton" style="height: 20px; width: 100%;"></div>
<div class="skeleton mt-2" style="height: 20px; width: 80%;"></div>
```

---

## 🎨 Utility Classes

### Gradients
```html
<div class="bg-gradient-primary">Primary gradient background</div>
<div class="bg-gradient-success">Success gradient</div>
<div class="bg-gradient-sunset">Sunset gradient</div>
<span class="text-gradient">Gradient text</span>
```

### Shadows
```html
<div class="shadow-soft">Subtle shadow</div>
<div class="shadow-medium">Medium shadow</div>
<div class="shadow-hard">Strong shadow</div>
```

### Border Radius
```html
<div class="border-radius-lg">Large rounded</div>
<div class="border-radius-xl">Extra large rounded</div>
```

---

## 📱 Responsive Design

### Breakpoints (Bootstrap 5.3.8)
- **xs**: < 576px (mobile)
- **sm**: ≥ 576px (large mobile)
- **md**: ≥ 768px (tablet)
- **lg**: ≥ 992px (small desktop)
- **xl**: ≥ 1200px (desktop)
- **xxl**: ≥ 1400px (large desktop)

### Mobile Optimizations
- Touch-friendly targets (min 44x44px)
- Reduced animations on mobile
- Stacked layouts
- Larger font sizes
- Simplified navigation

---

## ♿ Accessibility

### Focus States
All interactive elements have visible focus outlines:
```css
.focus-visible:focus {
	outline: 3px solid var(--primary);
	outline-offset: 2px;
}
```

### Screen Reader Support
```html
<span class="sr-only">Hidden text for screen readers</span>
```

### Color Contrast
All text meets WCAG AA standards:
- Normal text: 4.5:1 minimum
- Large text: 3:1 minimum
- UI components: 3:1 minimum

### Keyboard Navigation
- Tab order preserved
- Escape closes modals/dropdowns
- Enter activates buttons/links
- Arrow keys for menus

---

## 🚀 Performance

### CSS Optimization
- CSS variables for theme consistency
- Hardware-accelerated transforms (`translateY`, `scale`)
- `will-change` on heavy animations
- Minimal repaint/reflow

### Best Practices
- Use `transform` over `top`/`left`
- Prefer `opacity` for fade effects
- Batch DOM reads/writes
- Debounce scroll/resize events

---

## 🎓 Teaching Points for Microservices Course

### 1. **Design Systems in Distributed Teams**
   - Shared design tokens across services
   - Component library versioning
   - Theme customization per service
   - Brand consistency vs. service autonomy

### 2. **CSS Architecture**
   - Opt-in enhancements vs. global overrides
   - Naming conventions (BEM-like)
   - Specificity management
   - Maintainability at scale

### 3. **Progressive Enhancement**
   - Core experience works everywhere
   - Enhanced features for modern browsers
   - Graceful degradation
   - Feature detection

### 4. **Front-End Performance**
   - CDN vs. bundled assets
   - Critical CSS extraction
   - Lazy loading strategies
   - Cache-busting techniques

### 5. **Accessibility First**
   - Semantic HTML
   - ARIA roles and attributes
   - Keyboard navigation
   - Screen reader testing

---

## 🔧 Customization Guide

### Change Primary Color
```css
:root {
	--primary: #your-color;
	--primary-dark: #darker-shade;
	--primary-light: #lighter-shade;
}
```

### Adjust Shadow Intensity
```css
:root {
	--shadow-md: 0 4px 8px rgba(0, 0, 0, 0.12); /* Increase last value */
}
```

### Modify Transitions
```css
:root {
	--transition-base: 150ms; /* Faster */
	--transition-base: 400ms; /* Slower */
}
```

### Override Border Radius
```css
:root {
	--radius-md: 4px;   /* Square */
	--radius-md: 12px;  /* More rounded */
}
```

---

## 📦 What's Different from Before

### Removed (Aggressive Overrides)
- ❌ Global `.card:hover` lift
- ❌ Forced gradient on `.card-title`
- ❌ Override of `.btn-success`, `.btn-primary`
- ❌ Override of `.bg-warning`
- ❌ Global `.nav-link` changes

### Added (Opt-In Enhancements)
- ✅ `.card-hover` class for lift effect
- ✅ `.product-card` for product-specific styling
- ✅ `.btn-gradient-*` for special gradient buttons
- ✅ `.badge-gradient-*` for custom badges
- ✅ Comprehensive design token system
- ✅ Professional animation library
- ✅ Accessibility utilities
- ✅ Responsive utilities

### Result
- ✅ Bootstrap works normally
- ✅ Custom styles available when needed
- ✅ No unexpected visual changes
- ✅ Better maintainability
- ✅ Easier debugging

---

## 📚 Resources

- [Bootstrap 5.3.8 Docs](https://getbootstrap.com/docs/5.3/)
- [Bootstrap Icons](https://icons.getbootstrap.com/)
- [CSS Variables MDN](https://developer.mozilla.org/en-US/docs/Web/CSS/Using_CSS_custom_properties)
- [Web Accessibility Initiative](https://www.w3.org/WAI/)
- [Material Design Motion](https://material.io/design/motion)

---

**Version:** 2.0 Professional  
**Last Updated:** 2025  
**Compatibility:** Bootstrap 5.3.8, Modern Browsers (Chrome, Firefox, Safari, Edge)
