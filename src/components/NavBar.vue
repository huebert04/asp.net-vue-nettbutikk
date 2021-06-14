<template>
  <v-card>
    <v-app-bar dark prominent>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" absolute bottom temporary >
      <v-list nav dense>
        <v-list-item-group v-model="group" active-class="deep-purple--text text--accent-4">
        <v-list-item v-for="item in listItems" :key="item.title" :to="item.path">
          <v-list-item-action><v-icon>{{ item.icon }}</v-icon></v-list-item-action>
          <v-list-item-content>{{item.title}}</v-list-item-content>
        </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <router-view></router-view>
    </v-main> 
  </v-card>
  
</template>

<script>
export default {
    name: 'NavBar',
    props: ['drawer', 'group'],
    data() {
      return {
        name: 'Vue SPA Nettbutikk',
        sidebar: false,
        listItems: [
          {title: 'Home', path: '/', icon: 'home'},
          {title: 'Products', path: '/products', icon: 'basket'}
        ]
      }
    },
    watch: {
      drawer(value) {
        return value;
      }
    }
}
</script>

<style>
</style>