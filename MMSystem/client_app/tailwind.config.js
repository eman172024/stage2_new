const colors = require('tailwindcss/colors')

module.exports = {
    purge: [],
    darkMode: false, // or 'media' or 'class'
    theme: {
        fontFamily: {
            'sans': ['Tajawal'],
        },
        screens: {
            'xs': '426px',
            'sm': '640px',
            'md': '800px',
            'lg': '1024px',
            'xl': '1280px',
            '2xl': '1440px',
            '3xl': '1920px',
            '4xl': '2560px',
        },
        extend: {
            minHeight: {
                64: '16rem'
            },
            colors: {
                cyan: colors.cyan,
            }
        },
    },
    variants: {
        extend: {
            borderWidth: ['hover'],
        },
    },
    plugins: [],
    corePlugins: {
        container: false,
    }
}