module.exports = {
  purge: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    fontFamily: {
      'sans': ['Tajawal'],
    },
    extend: {
      colors: {
        primary: {
            blue: '#152b67',
            golden: '#d3c360',
        },
    },
      minHeight: {
        '24': '6rem',
        '72': '18rem',
        '80': '20rem',
      }
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
